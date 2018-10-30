namespace PointOfSale
{
    partial class MainForm
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
           this.authenticateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
           this.menuStrip1.SuspendLayout();
           this.SuspendLayout();
           // 
           // menuStrip1
           // 
           this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticateToolStripMenuItem,
            this.actionsToolStripMenuItem});
           this.menuStrip1.Location = new System.Drawing.Point(0, 0);
           this.menuStrip1.Name = "menuStrip1";
           this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
           this.menuStrip1.Size = new System.Drawing.Size(1280, 28);
           this.menuStrip1.TabIndex = 1;
           this.menuStrip1.Text = "menuStrip1";
           // 
           // authenticateToolStripMenuItem
           // 
           this.authenticateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
           this.authenticateToolStripMenuItem.Name = "authenticateToolStripMenuItem";
           this.authenticateToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
           this.authenticateToolStripMenuItem.Text = "Authenticate";
           // 
           // loginToolStripMenuItem
           // 
           this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
           this.loginToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
           this.loginToolStripMenuItem.Text = "Login";
           this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
           // 
           // logoutToolStripMenuItem
           // 
           this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
           this.logoutToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
           this.logoutToolStripMenuItem.Text = "Logout";
           this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
           // 
           // exitToolStripMenuItem
           // 
           this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
           this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
           this.exitToolStripMenuItem.Text = "Exit";
           this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
           // 
           // actionsToolStripMenuItem
           // 
           this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryToolStripMenuItem});
           this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
           this.actionsToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
           this.actionsToolStripMenuItem.Text = "Actions";
           // 
           // queryToolStripMenuItem
           // 
           this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
           this.queryToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
           this.queryToolStripMenuItem.Text = "Query";
           this.queryToolStripMenuItem.Click += new System.EventHandler(this.queryToolStripMenuItem_Click);
           // 
           // MainForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(1280, 471);
           this.Controls.Add(this.menuStrip1);
           this.IsMdiContainer = true;
           this.MainMenuStrip = this.menuStrip1;
           this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.Name = "MainForm";
           this.Text = "Checkout";
           this.menuStrip1.ResumeLayout(false);
           this.menuStrip1.PerformLayout();
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem authenticateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
    }
}

