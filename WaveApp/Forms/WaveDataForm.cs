using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FDDesigner.Forms;

namespace WaveApp.Forms
{
    public partial class WaveDataForm : DockForm
    {
        protected DateTime lastUpdate = DateTime.MinValue;
        public DateTime LastUpdate
        {
            get
            {
                return lastUpdate;
            }
            set
            {
                lastUpdate = value;
            }
        }
        public WaveDataForm()
        {
            InitializeComponent();
        }
        public virtual void UpdateData() { }
    }
}
