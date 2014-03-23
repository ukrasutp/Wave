using System;
using System.Windows.Forms;
using System.Reflection;

//using AM.Localize;
using Logger;
using Npgsql;

namespace WaveApp
{
    /// <summary>Форма ввода логина и пароля</summary>
    public partial class LoginForm : Form
    {
        /// <summary>Текущий уровень доступа пользователя</summary>
        public int CurrentUserAccess { get; set; }
        /// <summary>Текущий пользователь</summary>
        public string CurrentUserName { get; set; }
        /// <summary>Числовой идентификатор пользователя</summary>
        public int CurrentUserID { get; set; }

        private string loginError = "Неверное имя пользователя или пароль";

        /// <summary>Конструктор</summary>
        public LoginForm()
        {
            InitializeComponent();
            //this.Text = Localizator.LocalizeByKey( "$user_enter" );
            //label1.Text = Localizator.LocalizeByKey( "$login" );
            //label2.Text = Localizator.LocalizeByKey( "$password" );
            //okBtn.Text = Localizator.LocalizeByKey( "$enter" );
            //cancelBtn.Text = Localizator.LocalizeByKey( "$cancel" );

            //loginError = Localizator.LocalizeByKey( "$login_error" );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int user_id = -1;
            int level = 0;
            using (NpgsqlConnection connection = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=Attiz092006;Database=Wave"))//WaveEnvirument.ConnectionString))
            {
                //connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT public.__user_login(:login, :password);"))
                {
                    NpgsqlParameter param_value = new NpgsqlParameter(":login",System.Data.DbType.String);
                    param_value.Value = loginTextBox.Text.Trim();
                    command.Parameters.Add(param_value);
                    param_value = new NpgsqlParameter(":password",System.Data.DbType.String);
                    param_value.Value = loginTextBox.Text.Trim();
                    command.Parameters.Add(param_value);
                    try
                    {
                        connection.Open();
                        command.Connection = connection;
                        Object result = command.ExecuteScalar();
                        if (Convert.ToInt16(result) > 0)
                        {
                            WaveEnvirument.CurrentUser.AccessLevel = Convert.ToInt16(result); 
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            Close();
                        }
                        else
                        {

                            MessageBox.Show("Неверное имя пользователя или пароль", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
