using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Reflection;

using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.IO;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml;

namespace WaveApp.DB
{
    /// <summary>
    /// Класс обобщает методы работы с БД АИС СОАИ
    /// </summary>
    public static class DBHandler
    {
        public static event Action OnOpenDataSource;
        public static event Action OnCloseDataSource;
        [Browsable(false)]
        public static string DBConnectionString
        {
            get
            {
                return AppDomain.CurrentDomain.GetData("CnnctnStr") as String;
            }

        }
        public static Boolean IsOpenDataSource = false;
       
    }
}
