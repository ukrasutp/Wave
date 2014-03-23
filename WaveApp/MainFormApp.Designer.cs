namespace WaveApp
{
    partial class MainFormApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormApp));
            this.dockContainerStudio = new AIMS.Libraries.Forms.Docking.DockContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.login_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dockContainerStudio
            // 
            this.dockContainerStudio.ActiveAutoHideContent = null;
            this.dockContainerStudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockContainerStudio.DocumentStyle = AIMS.Libraries.Forms.Docking.DocumentStyles.DockingWindow;
            this.dockContainerStudio.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockContainerStudio.Location = new System.Drawing.Point(0, 24);
            this.dockContainerStudio.Name = "dockContainerStudio";
            this.dockContainerStudio.ShowDocumentIcon = true;
            this.dockContainerStudio.Size = new System.Drawing.Size(909, 422);
            this.dockContainerStudio.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(909, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.login_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(909, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // login_toolStripButton
            // 
            this.login_toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.login_toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("login_toolStripButton.Image")));
            this.login_toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.login_toolStripButton.Name = "login_toolStripButton";
            this.login_toolStripButton.Size = new System.Drawing.Size(23, 22);
            this.login_toolStripButton.Text = "toolStripButton1";
            this.login_toolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // MainFormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 446);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dockContainerStudio);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFormApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormApp_FormClosed);
            this.Load += new System.EventHandler(this.MainFormApp_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AIMS.Libraries.Forms.Docking.DockContainer dockContainerStudio;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton login_toolStripButton;
    }
}

