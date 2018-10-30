namespace AccountManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AddAccountButton = new System.Windows.Forms.Button();
            this.AccountsDataGridView = new System.Windows.Forms.DataGridView();
            this.AccountNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Accounts";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(54, 257);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(169, 20);
            this.NameTextBox.TabIndex = 2;
            // 
            // AddAccountButton
            // 
            this.AddAccountButton.Location = new System.Drawing.Point(229, 255);
            this.AddAccountButton.Name = "AddAccountButton";
            this.AddAccountButton.Size = new System.Drawing.Size(98, 23);
            this.AddAccountButton.TabIndex = 3;
            this.AddAccountButton.Text = "Add Account";
            this.AddAccountButton.UseVisualStyleBackColor = true;
            this.AddAccountButton.Click += new System.EventHandler(this.AddAccountButton_Click);
            // 
            // AccountsDataGridView
            // 
            this.AccountsDataGridView.AllowUserToAddRows = false;
            this.AccountsDataGridView.AllowUserToDeleteRows = false;
            this.AccountsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccountNumber,
            this.AccountDetails});
            this.AccountsDataGridView.Location = new System.Drawing.Point(12, 29);
            this.AccountsDataGridView.MultiSelect = false;
            this.AccountsDataGridView.Name = "AccountsDataGridView";
            this.AccountsDataGridView.ReadOnly = true;
            this.AccountsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AccountsDataGridView.Size = new System.Drawing.Size(506, 210);
            this.AccountsDataGridView.TabIndex = 4;
            this.AccountsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountsDataGridView_CellDoubleClick);
            // 
            // AccountNumber
            // 
            this.AccountNumber.HeaderText = "#";
            this.AccountNumber.Name = "AccountNumber";
            this.AccountNumber.ReadOnly = true;
            this.AccountNumber.Width = 30;
            // 
            // AccountDetails
            // 
            this.AccountDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AccountDetails.HeaderText = "Account Details";
            this.AccountDetails.Name = "AccountDetails";
            this.AccountDetails.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // MainForm
            // 
            this.AcceptButton = this.AddAccountButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 296);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AccountsDataGridView);
            this.Controls.Add(this.AddAccountButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Manager";
            ((System.ComponentModel.ISupportInitialize)(this.AccountsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button AddAccountButton;
        private System.Windows.Forms.DataGridView AccountsDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountDetails;
    }
}