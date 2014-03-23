namespace WaveApp.Forms
{
    partial class PropertyGridForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyGridForm));
            this.objectNamelabel = new System.Windows.Forms.Label();
            this.objectPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.objectPanel = new System.Windows.Forms.Panel();
            this.objectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectNamelabel
            // 
            this.objectNamelabel.AutoSize = true;
            this.objectNamelabel.Location = new System.Drawing.Point(12, 6);
            this.objectNamelabel.Name = "objectNamelabel";
            this.objectNamelabel.Size = new System.Drawing.Size(0, 15);
            this.objectNamelabel.TabIndex = 0;
            this.objectNamelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objectPropertyGrid
            // 
            this.objectPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectPropertyGrid.Location = new System.Drawing.Point(0, 27);
            this.objectPropertyGrid.Margin = new System.Windows.Forms.Padding(2);
            this.objectPropertyGrid.Name = "objectPropertyGrid";
            this.objectPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.objectPropertyGrid.Size = new System.Drawing.Size(302, 569);
            this.objectPropertyGrid.TabIndex = 3;
            this.objectPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.objectPropertyGrid_PropertyValueChanged);
            this.objectPropertyGrid.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.objectPropertyGrid_SelectedGridItemChanged);
            this.objectPropertyGrid.SelectedObjectsChanged += new System.EventHandler(this.objectPropertyGrid_SelectedObjectsChanged);
            // 
            // objectPanel
            // 
            this.objectPanel.AccessibleName = "";
            this.objectPanel.Controls.Add(this.objectNamelabel);
            this.objectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.objectPanel.Location = new System.Drawing.Point(0, 0);
            this.objectPanel.Name = "objectPanel";
            this.objectPanel.Size = new System.Drawing.Size(302, 27);
            this.objectPanel.TabIndex = 2;
            // 
            // PropertyGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 596);
            this.Controls.Add(this.objectPropertyGrid);
            this.Controls.Add(this.objectPanel);
            this.DockableAreas = ((AIMS.Libraries.Forms.Docking.DockAreas)(((((AIMS.Libraries.Forms.Docking.DockAreas.Float | AIMS.Libraries.Forms.Docking.DockAreas.DockLeft) 
            | AIMS.Libraries.Forms.Docking.DockAreas.DockRight) 
            | AIMS.Libraries.Forms.Docking.DockAreas.DockTop) 
            | AIMS.Libraries.Forms.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PropertyGridForm";
            this.TabText = "AMPropertyGrid";
            this.Text = "AMPropertyGrid";
            this.objectPanel.ResumeLayout(false);
            this.objectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label objectNamelabel;
        private System.Windows.Forms.Panel objectPanel;
        /// <summary>
        /// 
        /// </summary>
        public System.Windows.Forms.PropertyGrid objectPropertyGrid;
    }
}