namespace PointOfSale
{
    partial class Login
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
           this.btnOK = new System.Windows.Forms.Button();
           this.txtUsername = new System.Windows.Forms.TextBox();
           this.txtPassword = new System.Windows.Forms.TextBox();
           this.label1 = new System.Windows.Forms.Label();
           this.btnPassword = new System.Windows.Forms.Label();
           this.btnCancel = new System.Windows.Forms.Button();
           this.SuspendLayout();
           // 
           // btnOK
           // 
           this.btnOK.Location = new System.Drawing.Point(97, 92);
           this.btnOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.btnOK.Name = "btnOK";
           this.btnOK.Size = new System.Drawing.Size(100, 28);
           this.btnOK.TabIndex = 5;
           this.btnOK.Text = "OK";
           this.btnOK.UseVisualStyleBackColor = true;
           this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
           // 
           // txtUsername
           // 
           this.txtUsername.Location = new System.Drawing.Point(120, 15);
           this.txtUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.txtUsername.Name = "txtUsername";
           this.txtUsername.Size = new System.Drawing.Size(252, 22);
           this.txtUsername.TabIndex = 1;
           // 
           // txtPassword
           // 
           this.txtPassword.Location = new System.Drawing.Point(120, 47);
           this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.txtPassword.Name = "txtPassword";
           this.txtPassword.PasswordChar = '*';
           this.txtPassword.Size = new System.Drawing.Size(252, 22);
           this.txtPassword.TabIndex = 3;
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(16, 18);
           this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(73, 17);
           this.label1.TabIndex = 0;
           this.label1.Text = "Username";
           // 
           // btnPassword
           // 
           this.btnPassword.AutoSize = true;
           this.btnPassword.Location = new System.Drawing.Point(16, 50);
           this.btnPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.btnPassword.Name = "btnPassword";
           this.btnPassword.Size = new System.Drawing.Size(69, 17);
           this.btnPassword.TabIndex = 2;
           this.btnPassword.Text = "Password";
           // 
           // btnCancel
           // 
           this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.btnCancel.Location = new System.Drawing.Point(205, 92);
           this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.btnCancel.Name = "btnCancel";
           this.btnCancel.Size = new System.Drawing.Size(100, 28);
           this.btnCancel.TabIndex = 6;
           this.btnCancel.Text = "Cancel";
           this.btnCancel.UseVisualStyleBackColor = true;
           this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
           // 
           // Login
           // 
           this.AcceptButton = this.btnOK;
           this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.CancelButton = this.btnCancel;
           this.ClientSize = new System.Drawing.Size(389, 138);
           this.Controls.Add(this.btnCancel);
           this.Controls.Add(this.btnPassword);
           this.Controls.Add(this.label1);
           this.Controls.Add(this.txtPassword);
           this.Controls.Add(this.txtUsername);
           this.Controls.Add(this.btnOK);
           this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
           this.Name = "Login";
           this.Text = "Login";
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label btnPassword;
        private System.Windows.Forms.Button btnCancel;
    }
}