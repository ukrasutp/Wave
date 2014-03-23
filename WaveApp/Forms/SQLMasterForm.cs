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
    public partial class SQLMasterForm : DockForm
    {
        private int selectedPage = 0;
        private List<TabPage> pages = new List<TabPage>();
        public SQLMasterForm()
        {
            InitializeComponent();
            pages.Add(tabPage1);
            pages.Add(tabPage2);
            pages.Add(tabPage3);
        }
        private void setSelectedPage(int index)
        {
            foreach (TabPage page in pages)
                page.Parent = null;
            pages[index].Parent = this.tCMasterPages;
        }
        private void chkbAllMarketplace_CheckedChanged(object sender, EventArgs e)
        {
            this.tVMarketPlace.Enabled = !chkbAllMarketplace.Checked;
            /*
            if (chkbAllMarketplace.Checked)
                for (int i = 0; i < chklbMarketplace.Items.Count; i++)
                    chklbMarketplace.SetItemChecked(i, true);
             */ 
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            //Перейти к мастеру настроек абонентов
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SQLMasterForm_Activated(object sender, EventArgs e)
        {

            
            
        }

        private void SQLMasterForm_Shown(object sender, EventArgs e)
        {
            tCMasterPages.SelectedIndex = 0;
            this.tabPage2.Parent = null;//.Hide();//.Enabled = tabPage2.Visible = false;
            this.tabPage3.Parent = null;// Hide();// Enabled = tabPage3.Visible = false;
        }

        private void btNext_Click_1(object sender, EventArgs e)
        {
            this.selectedPage++;
            if (selectedPage >= pages.Count - 1)
                selectedPage = pages.Count - 1;
            this.setSelectedPage(selectedPage);
            btNext.Enabled = (selectedPage < pages.Count - 1);
            bPrevios.Enabled = (selectedPage > 0);
        }

        private void bPrevios_Click(object sender, EventArgs e)
        {
            this.selectedPage--;
            if (selectedPage <= 0)
                selectedPage = 0;
            this.setSelectedPage(selectedPage);
            bPrevios.Enabled = (selectedPage > 0);
            btNext.Enabled = (selectedPage < pages.Count - 1);
        }
    }
}
