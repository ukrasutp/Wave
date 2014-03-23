using System;
using System.Reflection;
using AIMS.Libraries.Forms.Docking;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using FDDesigner.Forms;

namespace WaveApp.Forms
{
    /// <summary>Окно инспектора объектов</summary>
    public partial class PropertyGridForm : DockForm
    {
        private string mess = null;

        /// <summary>Конструктор</summary>
        public PropertyGridForm()
        {
            InitializeComponent();
            lastDockState = AIMS.Libraries.Forms.Docking.DockState.DockLeftAutoHide;
            
            
        }

        private void objectPropertyGrid_SelectedObjectsChanged(object sender, EventArgs e)
        {
            if (objectPropertyGrid.SelectedObjects is object[] &&
                (objectPropertyGrid.SelectedObjects as object[]).Length > 1)
            {
                objectNamelabel.Text = mess + " " + (objectPropertyGrid.SelectedObjects as object[]).Length.ToString();
            }
            else if (objectPropertyGrid.SelectedObject is object)
            {
                objectNamelabel.Text = objectPropertyGrid.SelectedObject.ToString();
                /*
                    string.Empty;
                PropertyInfo pi = objectPropertyGrid.SelectedObject.GetType().GetProperty("Name", BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (pi != null)
                    objectNamelabel.Text = pi.GetValue(objectPropertyGrid.SelectedObject, null) + " ";
                objectNamelabel.Text += objectPropertyGrid.SelectedObject.GetType().FullName;
                 */ 
            }
            else
                objectNamelabel.Text = string.Empty;
            objectNamelabel.Left = (objectPanel.Width - objectNamelabel.Width) / 2;
        }
        /// <summary>Обработчик выбора элемента</summary>
        public void OnSelectedObject(object sender, EventArgs e)
        {
            if (sender == null)
                objectPropertyGrid.SelectedObject = null;
            else if (sender is object[])
                objectPropertyGrid.SelectedObjects = (sender as object[]);
            else
                objectPropertyGrid.SelectedObjects = new object[] { sender };
        }

        private void objectPropertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
        {
            if (objectPropertyGrid.SelectedObject != null)
            {
                objectNamelabel.Text = objectPropertyGrid.SelectedObject.ToString();
                PropertyInfo pi = objectPropertyGrid.SelectedObject.GetType().GetProperty(e.ChangedItem.PropertyDescriptor.Name);
                object[] attrs = pi.GetCustomAttributes(false);
            }
            objectPropertyGrid.Refresh();
        }

        private void objectPropertyGrid_SelectedGridItemChanged(object sender, System.Windows.Forms.SelectedGridItemChangedEventArgs e)
        {
            objectPropertyGrid.Refresh();
        }
    }
}