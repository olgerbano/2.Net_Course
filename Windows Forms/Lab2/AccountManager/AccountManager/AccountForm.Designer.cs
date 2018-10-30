namespace AccountManager
{
    partial class AccountForm
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
            this.AllTransactionsListBox = new System.Windows.Forms.ListBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.DetailsButton = new System.Windows.Forms.Button();
            this.WithdrawButton = new System.Windows.Forms.Button();
            this.DepositButton = new System.Windows.Forms.Button();
            this.AmountTextBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.DepositsListBox = new System.Windows.Forms.ListBox();
            this.WithdrawalsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SortByDateRadioButton = new System.Windows.Forms.RadioButton();
            this.SortByAmountRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NotesButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllTransactionsListBox
            // 
            this.AllTransactionsListBox.FormattingEnabled = true;
            this.AllTransactionsListBox.Location = new System.Drawing.Point(11, 72);
            this.AllTransactionsListBox.Name = "AllTransactionsListBox";
            this.AllTransactionsListBox.Size = new System.Drawing.Size(383, 69);
            this.AllTransactionsListBox.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 55);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(82, 13);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "All Transactions";
            // 
            // DetailsButton
            // 
            this.DetailsButton.Location = new System.Drawing.Point(199, 16);
            this.DetailsButton.Name = "DetailsButton";
            this.DetailsButton.Size = new System.Drawing.Size(66, 23);
            this.DetailsButton.TabIndex = 2;
            this.DetailsButton.Text = "Details";
            this.DetailsButton.UseVisualStyleBackColor = true;
            this.DetailsButton.Click += new System.EventHandler(this.DetailsButton_Click);
            // 
            // WithdrawButton
            // 
            this.WithdrawButton.Location = new System.Drawing.Point(264, 14);
            this.WithdrawButton.Name = "WithdrawButton";
            this.WithdrawButton.Size = new System.Drawing.Size(66, 23);
            this.WithdrawButton.TabIndex = 2;
            this.WithdrawButton.Text = "Withdraw";
            this.WithdrawButton.UseVisualStyleBackColor = true;
            this.WithdrawButton.Click += new System.EventHandler(this.WithdrawButton_Click);
            // 
            // DepositButton
            // 
            this.DepositButton.Location = new System.Drawing.Point(183, 14);
            this.DepositButton.Name = "DepositButton";
            this.DepositButton.Size = new System.Drawing.Size(66, 23);
            this.DepositButton.TabIndex = 1;
            this.DepositButton.Text = "Deposit";
            this.DepositButton.UseVisualStyleBackColor = true;
            this.DepositButton.Click += new System.EventHandler(this.DepositButton_Click);
            // 
            // AmountTextBox
            // 
            this.AmountTextBox.Location = new System.Drawing.Point(65, 14);
            this.AmountTextBox.Name = "AmountTextBox";
            this.AmountTextBox.Size = new System.Drawing.Size(100, 20);
            this.AmountTextBox.TabIndex = 0;
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
            // DepositsListBox
            // 
            this.DepositsListBox.FormattingEnabled = true;
            this.DepositsListBox.Location = new System.Drawing.Point(11, 172);
            this.DepositsListBox.Name = "DepositsListBox";
            this.DepositsListBox.Size = new System.Drawing.Size(383, 69);
            this.DepositsListBox.TabIndex = 4;
            // 
            // WithdrawalsListBox
            // 
            this.WithdrawalsListBox.FormattingEnabled = true;
            this.WithdrawalsListBox.Location = new System.Drawing.Point(11, 274);
            this.WithdrawalsListBox.Name = "WithdrawalsListBox";
            this.WithdrawalsListBox.Size = new System.Drawing.Size(383, 69);
            this.WithdrawalsListBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Deposits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Withdrawals";
            // 
            // SortByDateRadioButton
            // 
            this.SortByDateRadioButton.AutoSize = true;
            this.SortByDateRadioButton.Location = new System.Drawing.Point(6, 19);
            this.SortByDateRadioButton.Name = "SortByDateRadioButton";
            this.SortByDateRadioButton.Size = new System.Drawing.Size(84, 17);
            this.SortByDateRadioButton.TabIndex = 0;
            this.SortByDateRadioButton.TabStop = true;
            this.SortByDateRadioButton.Text = "Sort by Date";
            this.SortByDateRadioButton.UseVisualStyleBackColor = true;
            // 
            // SortByAmountRadioButton
            // 
            this.SortByAmountRadioButton.AutoSize = true;
            this.SortByAmountRadioButton.Location = new System.Drawing.Point(96, 19);
            this.SortByAmountRadioButton.Name = "SortByAmountRadioButton";
            this.SortByAmountRadioButton.Size = new System.Drawing.Size(97, 17);
            this.SortByAmountRadioButton.TabIndex = 1;
            this.SortByAmountRadioButton.TabStop = true;
            this.SortByAmountRadioButton.Text = "Sort by Amount";
            this.SortByAmountRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SortByDateRadioButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.SortByAmountRadioButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DetailsButton);
            this.groupBox1.Controls.Add(this.WithdrawalsListBox);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.DepositsListBox);
            this.groupBox1.Controls.Add(this.AllTransactionsListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 363);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transactions";
            // 
            // NotesButton
            // 
            this.NotesButton.Location = new System.Drawing.Point(355, 439);
            this.NotesButton.Name = "NotesButton";
            this.NotesButton.Size = new System.Drawing.Size(66, 23);
            this.NotesButton.TabIndex = 18;
            this.NotesButton.Text = "Notes";
            this.NotesButton.UseVisualStyleBackColor = true;
            this.NotesButton.Click += new System.EventHandler(this.NotesButton_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 474);
            this.Controls.Add(this.NotesButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.WithdrawButton);
            this.Controls.Add(this.DepositButton);
            this.Controls.Add(this.AmountTextBox);
            this.Controls.Add(this.Label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Account:";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListBox AllTransactionsListBox;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Button DetailsButton;
        internal System.Windows.Forms.Button WithdrawButton;
        internal System.Windows.Forms.Button DepositButton;
        internal System.Windows.Forms.TextBox AmountTextBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox DepositsListBox;
        internal System.Windows.Forms.ListBox WithdrawalsListBox;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton SortByDateRadioButton;
        private System.Windows.Forms.RadioButton SortByAmountRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button NotesButton;
    }
}

