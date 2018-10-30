namespace CalculatorApp
{
    partial class Form1
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
            this.valueTb = new System.Windows.Forms.TextBox();
            this.plusBtt = new System.Windows.Forms.Button();
            this.minusBtt = new System.Windows.Forms.Button();
            this.equalBtt = new System.Windows.Forms.Button();
            this.clearBtt = new System.Windows.Forms.Button();
            this.resultLbl = new System.Windows.Forms.Label();
            this.resultTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // valueTb
            // 
            this.valueTb.Location = new System.Drawing.Point(92, 40);
            this.valueTb.Name = "valueTb";
            this.valueTb.Size = new System.Drawing.Size(100, 20);
            this.valueTb.TabIndex = 0;
            this.valueTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valueTb.TextChanged += new System.EventHandler(this.ValueCanged);
            // 
            // plusBtt
            // 
            this.plusBtt.Location = new System.Drawing.Point(45, 102);
            this.plusBtt.Name = "plusBtt";
            this.plusBtt.Size = new System.Drawing.Size(35, 23);
            this.plusBtt.TabIndex = 1;
            this.plusBtt.Text = "+";
            this.plusBtt.UseVisualStyleBackColor = true;
            this.plusBtt.Click += new System.EventHandler(this.AddValue);
            // 
            // minusBtt
            // 
            this.minusBtt.Location = new System.Drawing.Point(99, 102);
            this.minusBtt.Name = "minusBtt";
            this.minusBtt.Size = new System.Drawing.Size(35, 23);
            this.minusBtt.TabIndex = 2;
            this.minusBtt.Text = "-";
            this.minusBtt.UseVisualStyleBackColor = true;
            this.minusBtt.Click += new System.EventHandler(this.SubstractValue);
            // 
            // equalBtt
            // 
            this.equalBtt.Location = new System.Drawing.Point(157, 102);
            this.equalBtt.Name = "equalBtt";
            this.equalBtt.Size = new System.Drawing.Size(35, 23);
            this.equalBtt.TabIndex = 3;
            this.equalBtt.Text = "=";
            this.equalBtt.UseVisualStyleBackColor = true;
            this.equalBtt.Click += new System.EventHandler(this.Equal);
            // 
            // clearBtt
            // 
            this.clearBtt.Location = new System.Drawing.Point(210, 102);
            this.clearBtt.Name = "clearBtt";
            this.clearBtt.Size = new System.Drawing.Size(35, 23);
            this.clearBtt.TabIndex = 4;
            this.clearBtt.Text = "C";
            this.clearBtt.UseVisualStyleBackColor = true;
            this.clearBtt.Click += new System.EventHandler(this.Clear);
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(120, 175);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(40, 13);
            this.resultLbl.TabIndex = 5;
            this.resultLbl.Text = "Result:";
            // 
            // resultTb
            // 
            this.resultTb.Enabled = false;
            this.resultTb.Location = new System.Drawing.Point(172, 172);
            this.resultTb.Name = "resultTb";
            this.resultTb.Size = new System.Drawing.Size(100, 20);
            this.resultTb.TabIndex = 6;
            this.resultTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.resultTb);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.clearBtt);
            this.Controls.Add(this.equalBtt);
            this.Controls.Add(this.minusBtt);
            this.Controls.Add(this.plusBtt);
            this.Controls.Add(this.valueTb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox valueTb;
        private System.Windows.Forms.Button plusBtt;
        private System.Windows.Forms.Button minusBtt;
        private System.Windows.Forms.Button equalBtt;
        private System.Windows.Forms.Button clearBtt;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.TextBox resultTb;
    }
}

