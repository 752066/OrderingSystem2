namespace CaterUI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuManagerInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMeber = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuQuite = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::CaterUI.Properties.Resources.menuBg;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuManagerInfo,
            this.menuMeber,
            this.menuTable,
            this.menuDish,
            this.menuOrder,
            this.menuQuite});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1045, 72);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuManagerInfo
            // 
            this.menuManagerInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuManagerInfo.Image = global::CaterUI.Properties.Resources.menuManager;
            this.menuManagerInfo.Name = "menuManagerInfo";
            this.menuManagerInfo.Size = new System.Drawing.Size(76, 68);
            this.menuManagerInfo.Text = "toolStripMenuItem1";
            this.menuManagerInfo.Click += new System.EventHandler(this.menuManagerInfo_Click);
            // 
            // menuMeber
            // 
            this.menuMeber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuMeber.Image = global::CaterUI.Properties.Resources.menuMember;
            this.menuMeber.Name = "menuMeber";
            this.menuMeber.Size = new System.Drawing.Size(76, 68);
            this.menuMeber.Text = "toolStripMenuItem2";
            this.menuMeber.Click += new System.EventHandler(this.menuMeber_Click);
            // 
            // menuTable
            // 
            this.menuTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuTable.Image = global::CaterUI.Properties.Resources.menuTable;
            this.menuTable.Name = "menuTable";
            this.menuTable.Size = new System.Drawing.Size(76, 68);
            this.menuTable.Text = "toolStripMenuItem3";
            // 
            // menuDish
            // 
            this.menuDish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuDish.Image = global::CaterUI.Properties.Resources.menuDish;
            this.menuDish.Name = "menuDish";
            this.menuDish.Size = new System.Drawing.Size(76, 68);
            this.menuDish.Text = "toolStripMenuItem4";
            // 
            // menuOrder
            // 
            this.menuOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuOrder.Image = global::CaterUI.Properties.Resources.menuOrder;
            this.menuOrder.Name = "menuOrder";
            this.menuOrder.Size = new System.Drawing.Size(76, 68);
            this.menuOrder.Text = "toolStripMenuItem5";
            // 
            // menuQuite
            // 
            this.menuQuite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.menuQuite.Image = global::CaterUI.Properties.Resources.menuQuit;
            this.menuQuite.Name = "menuQuite";
            this.menuQuite.Size = new System.Drawing.Size(76, 68);
            this.menuQuite.Text = "toolStripMenuItem6";
            this.menuQuite.Click += new System.EventHandler(this.menuQuite_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 542);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "餐厅管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuManagerInfo;
        private System.Windows.Forms.ToolStripMenuItem menuMeber;
        private System.Windows.Forms.ToolStripMenuItem menuTable;
        private System.Windows.Forms.ToolStripMenuItem menuDish;
        private System.Windows.Forms.ToolStripMenuItem menuOrder;
        private System.Windows.Forms.ToolStripMenuItem menuQuite;
    }
}