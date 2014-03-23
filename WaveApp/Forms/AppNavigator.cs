using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AIMS.Libraries.Forms.Docking;
using System.Reflection;
using Npgsql;

namespace WaveApp.Forms
{
    public partial class AppNavigator : WaveDataForm

    {
        private AppNavigator navigateForm = null;
        public AppNavigator()
        {
            InitializeComponent();
            
            
        }
        /// <summary>
        /// Обновить данные
        /// </summary>
        protected override void UpdateDefaultButton()
        {
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(WaveEnvirument.ConnectionString);
            try
            {
                npgSqlConnection.Open();
                
                    //формируем запрос
                    using (NpgsqlCommand sqlQuery = new NpgsqlCommand("SELECT * FROM public.object_structure;", npgSqlConnection))
                    {
                        NpgsqlDataReader reader = sqlQuery.ExecuteReader();
                        lastUpdate = DateTime.Now;

                        while (reader.Read())
                        {
                            

                        }
                    
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                
            }
        }
    }
}
