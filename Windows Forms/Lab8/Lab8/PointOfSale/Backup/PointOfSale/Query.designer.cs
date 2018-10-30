namespace PointOfSale
{
   partial class Query
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
          this.txtProduct = new System.Windows.Forms.TextBox();
          this.btnQuery = new System.Windows.Forms.Button();
          this.label2 = new System.Windows.Forms.Label();
          this.lblProduct = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.lblStock = new System.Windows.Forms.Label();
          this.label6 = new System.Windows.Forms.Label();
          this.lblPrice = new System.Windows.Forms.Label();
          this.gbResults = new System.Windows.Forms.GroupBox();
          this.lblPrincipal = new System.Windows.Forms.Label();
          this.gbResults.SuspendLayout();
          this.SuspendLayout();
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(7, 10);
          this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(44, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "Product";
          // 
          // txtProduct
          // 
          this.txtProduct.Location = new System.Drawing.Point(54, 7);
          this.txtProduct.Margin = new System.Windows.Forms.Padding(2);
          this.txtProduct.Name = "txtProduct";
          this.txtProduct.Size = new System.Drawing.Size(194, 20);
          this.txtProduct.TabIndex = 1;
          this.txtProduct.TextChanged += new System.EventHandler(this.txtProduct_TextChanged);
          // 
          // btnQuery
          // 
          this.btnQuery.Location = new System.Drawing.Point(254, 4);
          this.btnQuery.Margin = new System.Windows.Forms.Padding(2);
          this.btnQuery.Name = "btnQuery";
          this.btnQuery.Size = new System.Drawing.Size(56, 24);
          this.btnQuery.TabIndex = 2;
          this.btnQuery.Text = "Query";
          this.btnQuery.UseVisualStyleBackColor = true;
          this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(11, 27);
          this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(44, 13);
          this.label2.TabIndex = 3;
          this.label2.Text = "Product";
          // 
          // lblProduct
          // 
          this.lblProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.lblProduct.Location = new System.Drawing.Point(86, 26);
          this.lblProduct.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.lblProduct.Name = "lblProduct";
          this.lblProduct.Size = new System.Drawing.Size(200, 19);
          this.lblProduct.TabIndex = 4;
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(11, 54);
          this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(35, 13);
          this.label4.TabIndex = 5;
          this.label4.Text = "Stock";
          // 
          // lblStock
          // 
          this.lblStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.lblStock.Location = new System.Drawing.Point(86, 53);
          this.lblStock.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.lblStock.Name = "lblStock";
          this.lblStock.Size = new System.Drawing.Size(200, 19);
          this.lblStock.TabIndex = 6;
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(11, 81);
          this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(58, 13);
          this.label6.TabIndex = 7;
          this.label6.Text = "Price each";
          // 
          // lblPrice
          // 
          this.lblPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.lblPrice.Location = new System.Drawing.Point(86, 80);
          this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.lblPrice.Name = "lblPrice";
          this.lblPrice.Size = new System.Drawing.Size(200, 19);
          this.lblPrice.TabIndex = 8;
          // 
          // gbResults
          // 
          this.gbResults.Controls.Add(this.lblPrice);
          this.gbResults.Controls.Add(this.label2);
          this.gbResults.Controls.Add(this.label6);
          this.gbResults.Controls.Add(this.lblProduct);
          this.gbResults.Controls.Add(this.lblStock);
          this.gbResults.Controls.Add(this.label4);
          this.gbResults.Location = new System.Drawing.Point(9, 38);
          this.gbResults.Margin = new System.Windows.Forms.Padding(2);
          this.gbResults.Name = "gbResults";
          this.gbResults.Padding = new System.Windows.Forms.Padding(2);
          this.gbResults.Size = new System.Drawing.Size(301, 114);
          this.gbResults.TabIndex = 9;
          this.gbResults.TabStop = false;
          this.gbResults.Text = "Results";
          // 
          // lblPrincipal
          // 
          this.lblPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.lblPrincipal.Location = new System.Drawing.Point(7, 154);
          this.lblPrincipal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
          this.lblPrincipal.Name = "lblPrincipal";
          this.lblPrincipal.Size = new System.Drawing.Size(303, 17);
          this.lblPrincipal.TabIndex = 10;
          // 
          // Query
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(321, 180);
          this.Controls.Add(this.lblPrincipal);
          this.Controls.Add(this.gbResults);
          this.Controls.Add(this.btnQuery);
          this.Controls.Add(this.txtProduct);
          this.Controls.Add(this.label1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Margin = new System.Windows.Forms.Padding(2);
          this.Name = "Query";
          this.Text = "Query";
          this.Activated += new System.EventHandler(this.Query_Activated);
          this.gbResults.ResumeLayout(false);
          this.gbResults.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox txtProduct;
      private System.Windows.Forms.Button btnQuery;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label lblProduct;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label lblStock;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.Label lblPrice;
      private System.Windows.Forms.GroupBox gbResults;
      private System.Windows.Forms.Label lblPrincipal;
   }
}