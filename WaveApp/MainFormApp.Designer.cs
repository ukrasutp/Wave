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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.dockContainerStudio = new AIMS.Libraries.Forms.Docking.DockContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.login_toolStripButton = new System.Windows.Forms.ToolStripButton();
            this.Exit_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(909, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.dockContainerStudio);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(909, 397);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(909, 422);
            this.toolStripContainer1.TabIndex = 6;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // dockContainerStudio
            // 
            this.dockContainerStudio.ActiveAutoHideContent = null;
            this.dockContainerStudio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockContainerStudio.DocumentStyle = AIMS.Libraries.Forms.Docking.DocumentStyles.DockingWindow;
            this.dockContainerStudio.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockContainerStudio.Location = new System.Drawing.Point(0, 0);
            this.dockContainerStudio.Name = "dockContainerStudio";
            this.dockContainerStudio.ShowDocumentIcon = true;
            this.dockContainerStudio.Size = new System.Drawing.Size(909, 397);
            this.dockContainerStudio.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Exit_ToolStripButton,
            this.login_toolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(58, 25);
            this.toolStrip1.TabIndex = 6;
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
            // 
            // Exit_ToolStripButton
            // 
            this.Exit_ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Exit_ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("Exit_ToolStripButton.Image")));
            this.Exit_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Exit_ToolStripButton.Name = "Exit_ToolStripButton";
            this.Exit_ToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.Exit_ToolStripButton.Text = "В&ыход";
            this.Exit_ToolStripButton.Click += new System.EventHandler(this.Exit_ToolStripButton_Click);
            // 
            // MainFormApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 446);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainFormApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АРМ \"Волна\"";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormApp_FormClosed);
            this.Load += new System.EventHandler(this.MainFormApp_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private AIMS.Libraries.Forms.Docking.DockContainer dockContainerStudio;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton login_toolStripButton;
        private System.Windows.Forms.ToolStripButton Exit_ToolStripButton;
    }
}

