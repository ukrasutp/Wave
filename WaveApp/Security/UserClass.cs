using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaveApp.Security
{
    public class UserClass
    {
        public string Login { get; set; }
        private int accessLevel = 9999;
        public int AccessLevel { get { return accessLevel; } set { accessLevel = value; } }
    }
}
