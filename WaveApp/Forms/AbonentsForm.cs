﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using FDDesigner.Forms;




namespace WaveApp.Forms
{
    public partial class AbonentsForm : DockForm
    {
        private const int refreshTime = 0;//время между обновлениями мс
        
        private BackgroundWorker backgroundGetDataFromTable = new System.ComponentModel.BackgroundWorker();

        private int number_trading_floor = 2;
        private int number_sector = 1;
        private int number_module = 0;

        //private const String functionName = "return_displayed_fields_of_abonents(number_trading_floor,number_sector,number_module);";//имя хранимой продцедуры
        private DataTable tableAbonentsNewData;//хранит в себе таблицу, являющуюся результатом хранимой продцедуры

        private String getFunctionName()
        {
            return "__displayed_fields_of_abonents("
                + (number_trading_floor != 0 ? number_trading_floor.ToString() : "")
                + (number_sector != 0 ? "," + number_sector.ToString() : "")
                + (number_module != 0 ? "," + number_module.ToString() : "")
                + ");";
        }



        public AbonentsForm()
        {
            InitializeComponent();
            backgroundGetDataFromTable.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundGetDataFromTable_DoWork);
            backgroundGetDataFromTable.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundGetDataFromTable_RunWorkerCompleted);
            //backgroundGetDataFromTable.RunWorkerAsync();

            numberTradingFloorLabel.Text = number_trading_floor.ToString();
            numberSectorLabel.Text = number_sector.ToString();

            //подстраиваемм ширину
            Column1.Width = (this.ClientSize.Width - dataGridView1.RowHeadersWidth) / 4;
            Column2.Width = (this.ClientSize.Width - dataGridView1.RowHeadersWidth) / 4;
            Column3.Width = (this.ClientSize.Width - dataGridView1.RowHeadersWidth) / 4;
            Column4.Width = (this.ClientSize.Width - dataGridView1.RowHeadersWidth) / 4;

        }

        public void UpdateData()
        {
            backgroundGetDataFromTable.RunWorkerAsync();
        }


        /// <summary>
        /// Получение таблицы из базы данных путем выполнения хранимой продцедуры
        /// </summary>
        /// <param name="nameOfFunc">Название хранимой продцедуры</param>
        /// <returns>Таблицу сгенерированную хранимой продцедурой</returns>

        private DataTable getDataFromDBByFunc(String nameOfFunc)
        {
            //устанавливаем соеденение с бд
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(WaveEnvirument.ConnectionString);

            //формируем запрос
            NpgsqlCommand sqlQuery = new NpgsqlCommand("SELECT * FROM " + nameOfFunc + ";", npgSqlConnection);
            try
            {
                npgSqlConnection.Open();

                //заносим результат в ДатаСет
                DataSet ds = new DataSet();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlQuery);
                da.Fill(ds);
                //da.Fill(0, 1, newData);

                return ds.Tables[0];//Возвращаем первую(единственную) таблицу из датасета
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                npgSqlConnection.Close();
            }
        }

        private DataTable getDataFromDBByQuery(String query)
        {
            //устанавливаем соеденение с бд
            NpgsqlConnection npgSqlConnection = new NpgsqlConnection(WaveEnvirument.ConnectionString);

            //формируем запрос
            NpgsqlCommand sqlQuery = new NpgsqlCommand(query, npgSqlConnection);
            try
            {
                npgSqlConnection.Open();

                //заносим результат в ДатаСет
                DataSet ds = new DataSet();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sqlQuery);
                da.Fill(ds);
                //da.Fill(0, 1, newData);

                return ds.Tables[0];//Возвращаем первую(единственную) таблицу из датасета
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                npgSqlConnection.Close();
            }
        }

        /// <summary>
        /// Обновление данных на форме
        /// </summary>
        private void refreshDataInDataGrid()
        {

            //делаем одинаковую размерность у датагрида и таблицы из бд если в таблице есть данные
            if (dataGridView1.RowCount != tableAbonentsNewData.Rows.Count && tableAbonentsNewData.Rows.Count > 0)
            {
                dataGridView1.RowCount = tableAbonentsNewData.Rows.Count;
            }
            /*
            if (dataGridView1.ColumnCount != newData.Columns.Count)
            {
                dataGridView1.ColumnCount = newData.Columns.Count;
            }*/


            //меняем значения по всем колонкам если они различные
            for (int column = 0; column < dataGridView1.ColumnCount; column++)
            {
                for (int row = 0; row < tableAbonentsNewData.Rows.Count; row++)
                {
                    //MessageBox.Show("row",row.ToString());
                    if (dataGridView1.Rows[row].Cells[column].Value != tableAbonentsNewData.Rows[row][column])
                    {
                        dataGridView1.Rows[row].Cells[column].Value = tableAbonentsNewData.Rows[row][column];
                    }
                }
            }
        }

        /// <summary>
        /// Метод вызываемый по завершению backgroundWorker
        /// </summary>
        private void backgroundGetDataFromTable_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //обновляем данные на форме
            refreshDataInDataGrid();
            //запускаем backgroundWorker еще раз
            // backgroundGetDataFromTable.RunWorkerAsync();
        }

        /// <summary>
        /// Тело backgroundWorker
        /// </summary>
        private void backgroundGetDataFromTable_DoWork(object sender, DoWorkEventArgs e)
        {
            //выполняем хранимую продцедуру
            tableAbonentsNewData = getDataFromDBByFunc(getFunctionName());
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateData();
        }


        private void AbonentsForm_Resize(object sender, EventArgs e)
        {
            //подстраиваемм ширину
            Column1.Width = (this.ClientSize.Width - dataGridView1.RowHeadersWidth) / 4;
            Column2.Width = (this.ClientSize.Width - dataGridView1.RowHeadersWidth) / 4;
            Column3.Width = (this.ClientSize.Width - dataGridView1.RowHeadersWidth) / 4;
            Column4.Width = (this.ClientSize.Width - dataGridView1.RowHeadersWidth) / 4;
        }

        /// <summary>
        /// Заполняет графики
        /// </summary>
        /// <param name="fromDate">Начальная дата</param>
        /// <param name="toDate">Конечня дата</param>

        private void updateChartData(DateTime fromDate, DateTime toDate)
        {
            HashSet<DateTime> times = new HashSet<DateTime>();

            DataRowCollection timesRow = getDataFromDBByQuery("Select polling_time from abonentshistory where polling_time>='" + fromDate + "' and polling_time<='" + toDate + "' order by polling_time;").Rows; //таблица значений,(time) упорядоченная по времени
            for (int i = 0; i < timesRow.Count; i++)
            {
                times.Add((DateTime)timesRow[i][0]);
            }

            DateTime timeCounter;


            for (int counter = 0; counter < times.Count; counter++)//перебираем все времена
            {
                timeCounter = times.ElementAt(counter);
                DataRowCollection row = getDataFromDBByQuery("Select amount_electricity_consumed from abonentshistory where polling_time='" + timeCounter + "';").Rows; //таблица значений,(electrisity)
                double sumElectrisity = 0;

                for (int j = 0; j < row.Count; j++)//суммируем все значения с одинаковым временем
                {
                    sumElectrisity += (double)row[j][0];
                }

                chart1.Series[0].Points.AddXY(timeCounter, sumElectrisity);//записываем значение
                chart2.Series[0].Points.AddXY(timeCounter, sumElectrisity);//записываем значение

            }

        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            //createCharData();
            updateChartData(DateTime.Now.AddDays(-5), DateTime.Now);


            
        }

        private void tabPage2_Leave(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Таймер который обрабатывает обновления графиков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //refreshCharts();
        }



    }
}
