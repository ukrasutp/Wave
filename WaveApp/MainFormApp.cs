using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WaveApp.Forms;
using AIMS.Libraries.Forms.Docking;
using System.Reflection;
using Npgsql;
using System.Collections;

namespace WaveApp
{
    public partial class MainFormApp : Form
    {
        private event Action changeAbonentsData;
        private event Action changeEventsData;
        private event Action changeObjectStructureData;
        private SQLMasterForm sqlMasterForm = null;
        private AppNavigator navigateForm = null;
        private AbonentsForm abonentsForm = null;
        private Boolean active = false;
        private System.Threading.Thread updateAppThread = null;
        public MainFormApp()
        {
            InitializeComponent();            
                    
            DockState defaultDockState;
            FieldInfo fi;
            defaultDockState = DockState.Unknown;
            //Создание формы мастера запросов
            sqlMasterForm = new SQLMasterForm();
            sqlMasterForm.Tag = "#sqlMasterForm";
            fi = sqlMasterForm.GetType().GetField("lastDockState", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi != null)
                defaultDockState = (DockState)fi.GetValue(sqlMasterForm);
            defaultDockState = defaultDockState == DockState.Unknown ? DockState.DockLeft : defaultDockState;
            sqlMasterForm.Show(dockContainerStudio, defaultDockState);
            //Создание навигационной формы проекта 
            navigateForm = new AppNavigator();
            navigateForm.Tag = "$struct_project";
            //navigateForm.TabText = Localizator.LocalizeByKey("$struct_project");
            //navigateForm.DockStateChanged += new EventHandler(dockedPanel_DockStateChanged);
            //navigateForm.inspectTreeView.Click += new EventHandler(TreeView_Click);
            //navigateForm.OnEditTreePoint += new EventHandler(this.docreateEditor);

            fi = navigateForm.GetType().GetField("lastDockState", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi != null)
                defaultDockState = (DockState)fi.GetValue(navigateForm);
            defaultDockState = defaultDockState == DockState.Unknown ? DockState.DockLeft : defaultDockState;
            this.changeObjectStructureData += navigateForm.UpdateData;
            navigateForm.Show(dockContainerStudio, defaultDockState);

            abonentsForm = new AbonentsForm();
            this.changeAbonentsData += abonentsForm.UpdateData;
            abonentsForm.Tag = "$abonents_form";
            fi = abonentsForm.GetType().GetField("lastDockState", BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fi != null)
                defaultDockState = (DockState)fi.GetValue(abonentsForm);

            defaultDockState = defaultDockState == DockState.Unknown ? DockState.Document : defaultDockState;
            abonentsForm.Show(dockContainerStudio, defaultDockState);

            AppDomain.CurrentDomain.SetData("navigateForm", navigateForm);
            updateAppThread = new System.Threading.Thread(new System.Threading.ThreadStart(chekUpdateAppData));
            
            
        }

       
        /// <summary>
        /// Проверка обновления данных и формирование событий на обновление данных в формах
        /// </summary>
        private void chekUpdateAppData()
        {
            DateTime lastUpdate = DateTime.MinValue;
             //устанавливаем соеденение с бд
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(WaveEnvirument.ConnectionString);
            try
            {
                npgSqlConnection.Open();
                while (active)
                {
                    //формируем запрос
                    if (lastUpdate == DateTime.MinValue)
                    {
                        changeObjectStructureData.Invoke();
                        changeAbonentsData.Invoke();
                        
                        lastUpdate = DateTime.Now;
                    } else
                    using (NpgsqlCommand sqlQuery = new NpgsqlCommand("SELECT * FROM public.update_tbl_log WHERE event_time >= " + lastUpdate + ";", npgSqlConnection))
                    {
                        NpgsqlDataReader reader = sqlQuery.ExecuteReader();
                        lastUpdate = DateTime.Now;
                        while (reader.Read())
                        {
                            if ("abonents".Equals(Convert.ToString(reader["tbl_name"]).ToLower().Trim()))
                                changeAbonentsData.Invoke();

                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                System.Threading.Thread.Sleep(1000);
            }
        }
        /// <summary>Вход пользователя</summary>
        private void UserLoginAction()
        {
            //Считываем текущую строку соединения с базой данных
            LoginForm loginFrm = new LoginForm();
            DialogResult result = loginFrm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                /*
                userName = loginFrm.CurrentUserName;
                levelAccess = loginFrm.CurrentUserAccess;
                AMStudioUtils.user_id = loginFrm.CurrentUserID;
                toolStripStatusLabelUserName.Text = userName;
                 */
            }
            else if (result == System.Windows.Forms.DialogResult.Abort)
                Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            if (loginForm.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
            }
        }

        private void MainFormApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            active = false;
        }

        private void MainFormApp_Load(object sender, EventArgs e)
        {
            active = true;
            updateAppThread.Start();
        }

        private void Exit_ToolStripButton_Click(object sender, EventArgs e)
        {
            Exit();
        }
        public void Exit()
        {
            if (MessageBox.Show("Выйти из приложения?", "Подтвердите", MessageBoxButtons.OKCancel) == DialogResult.OK)
                Close();
        }
    }
}
