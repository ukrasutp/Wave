using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveApp.Security;

namespace WaveApp
{
    public static class WaveEnvirument
    {
        private static UserClass currentUser = null;
        public static UserClass CurrentUser { get { return currentUser; } set { currentUser = value;} }
        public static String ConnectionString 
        { 
        get {
             return "Server=" + Properties.Settings.Default.DBHost + ";Port=" + Convert.ToString(Properties.Settings.Default.DBPort) + ";User Id=" +
                                    Properties.Settings.Default.DBUser + ";Password=" + Properties.Settings.Default.DBPassWord + ";Database=" + Properties.Settings.Default.DBName;
        }
        }
    }
}
