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
            this.TransactionsListBox = new System.Windows.Forms.ListBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.DetailsButton = new System.Windows.Forms.Button();
            this.WithdrawButton = new System.Windows.Forms.Button();
            this.DepositButton = new System.Windows.Forms.Button();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TransactionsListBox
            // 
            this.TransactionsListBox.FormattingEnabled = true;
            this.TransactionsListBox.Location = new System.Drawing.Point(19, 71);
            this.TransactionsListBox.Name = "TransactionsListBox";
            this.TransactionsListBox.Size = new System.Drawing.Size(392, 147);
            this.TransactionsListBox.TabIndex = 13;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(16, 54);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(68, 13);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Transactions";
            // 
            // DetailsButton
            // 
            this.DetailsButton.Location = new System.Drawing.Point(345, 14);
            this.DetailsButton.Name = "DetailsButton";
            this.DetailsButton.Size = new System.Drawing.Size(66, 23);
            this.DetailsButton.TabIndex = 11;
            this.DetailsButton.Text = "Details";
            this.DetailsButton.UseVisualStyleBackColor = true;
            this.DetailsButton.Click += new System.EventHandler(this.DetailsButton_Click);
            // 
            // WithdrawButton
            // 
            this.WithdrawButton.Location = new System.Drawing.Point(264, 14);
            this.WithdrawButton.Name = "WithdrawButton";
            this.WithdrawButton.Size = new System.Drawing.Size(66, 23);
            this.WithdrawButton.TabIndex = 10;
            this.WithdrawButton.Text = "Withdraw";
            this.WithdrawButton.UseVisualStyleBackColor = true;
            this.WithdrawButton.Click += new System.EventHandler(this.WithdrawButton_Click);
            // 
            // DepositButton
            // 
            this.DepositButton.Location = new System.Drawing.Point(183, 14);
            this.DepositButton.Name = "DepositButton";
            this.DepositButton.Size = new System.Drawing.Size(66, 23);
            this.DepositButton.TabIndex = 9;
            this.DepositButton.Text = "Deposit";
            this.DepositButton.UseVisualStyleBackColor = true;
            this.DepositButton.Click += new System.EventHandler(this.DepositButton_Click);
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(65, 14);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(100, 20);
            this.AmountTextBox.TabIndex = 8;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 17);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(46, 13);
            this.Label1.TabIndex = 7;
            this.Label1.Text = "Amount:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 233);
            this.Controls.Add(this.TransactionsListBox);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.DetailsButton);
            this.Controls.Add(this.WithdrawButton);
            this.Controls.Add(this.DepositButton);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.Label1);
            this.Name = "MainForm";
            this.Text = "Account Manager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox TransactionsListBox;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button DetailsButton;
        internal System.Windows.Forms.Button WithdrawButton;
        internal System.Windows.Forms.Button DepositButton;
        internal System.Windows.Forms.TextBox AmountTextBox;
        internal System.Windows.Forms.Label Label1;
    }
}

