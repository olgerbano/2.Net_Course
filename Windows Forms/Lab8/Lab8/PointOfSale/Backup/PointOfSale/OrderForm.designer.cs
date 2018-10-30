namespace PointOfSale
{
    partial class OrderForm
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
           this.gbOrder = new System.Windows.Forms.GroupBox();
           this.label2 = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this.btnRemove = new System.Windows.Forms.Button();
           this.btnAdd = new System.Windows.Forms.Button();
           this.udQuantity = new System.Windows.Forms.NumericUpDown();
           this.comboProduct = new System.Windows.Forms.ComboBox();
           this.btnNew = new System.Windows.Forms.Button();
           this.btnOrder = new System.Windows.Forms.Button();
           this.btnRefund = new System.Windows.Forms.Button();
           this.lvOrder = new System.Windows.Forms.ListView();
           this.cbItem = new System.Windows.Forms.ColumnHeader();
           this.cbQuantity = new System.Windows.Forms.ColumnHeader();
           this.gbOrder.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this.udQuantity)).BeginInit();
           this.SuspendLayout();
           // 
           // gbOrder
           // 
           this.gbOrder.Controls.Add(this.label2);
           this.gbOrder.Controls.Add(this.label1);
           this.gbOrder.Controls.Add(this.btnRemove);
           this.gbOrder.Controls.Add(this.btnAdd);
           this.gbOrder.Controls.Add(this.udQuantity);
           this.gbOrder.Controls.Add(this.comboProduct);
           this.gbOrder.Location = new System.Drawing.Point(16, 15);
           this.gbOrder.Margin = new System.Windows.Forms.Padding(4);
           this.gbOrder.Name = "gbOrder";
           this.gbOrder.Padding = new System.Windows.Forms.Padding(4);
           this.gbOrder.Size = new System.Drawing.Size(316, 100);
           this.gbOrder.TabIndex = 0;
           this.gbOrder.TabStop = false;
           this.gbOrder.Text = "Order";
           // 
           // label2
           // 
           this.label2.AutoSize = true;
           this.label2.Location = new System.Drawing.Point(5, 63);
           this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(61, 17);
           this.label2.TabIndex = 4;
           this.label2.Text = "Quantity";
           // 
           // label1
           // 
           this.label1.AutoSize = true;
           this.label1.Location = new System.Drawing.Point(5, 28);
           this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(57, 17);
           this.label1.TabIndex = 2;
           this.label1.Text = "Product";
           // 
           // btnRemove
           // 
           this.btnRemove.Enabled = false;
           this.btnRemove.Location = new System.Drawing.Point(244, 60);
           this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
           this.btnRemove.Name = "btnRemove";
           this.btnRemove.Size = new System.Drawing.Size(57, 28);
           this.btnRemove.TabIndex = 7;
           this.btnRemove.Text = "<<<";
           this.btnRemove.UseVisualStyleBackColor = true;
           this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
           // 
           // btnAdd
           // 
           this.btnAdd.Enabled = false;
           this.btnAdd.Location = new System.Drawing.Point(245, 22);
           this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
           this.btnAdd.Name = "btnAdd";
           this.btnAdd.Size = new System.Drawing.Size(56, 28);
           this.btnAdd.TabIndex = 6;
           this.btnAdd.Text = ">>>";
           this.btnAdd.UseVisualStyleBackColor = true;
           this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
           // 
           // udQuantity
           // 
           this.udQuantity.Location = new System.Drawing.Point(76, 60);
           this.udQuantity.Margin = new System.Windows.Forms.Padding(4);
           this.udQuantity.Name = "udQuantity";
           this.udQuantity.Size = new System.Drawing.Size(160, 22);
           this.udQuantity.TabIndex = 5;
           this.udQuantity.ValueChanged += new System.EventHandler(this.udQuantity_ValueChanged);
           // 
           // comboProduct
           // 
           this.comboProduct.FormattingEnabled = true;
           this.comboProduct.Location = new System.Drawing.Point(76, 25);
           this.comboProduct.Margin = new System.Windows.Forms.Padding(4);
           this.comboProduct.Name = "comboProduct";
           this.comboProduct.Size = new System.Drawing.Size(160, 24);
           this.comboProduct.TabIndex = 3;
           this.comboProduct.SelectedIndexChanged += new System.EventHandler(this.comboProduct_SelectedIndexChanged);
           // 
           // btnNew
           // 
           this.btnNew.Enabled = false;
           this.btnNew.Location = new System.Drawing.Point(16, 123);
           this.btnNew.Margin = new System.Windows.Forms.Padding(4);
           this.btnNew.Name = "btnNew";
           this.btnNew.Size = new System.Drawing.Size(100, 28);
           this.btnNew.TabIndex = 9;
           this.btnNew.Text = "New";
           this.btnNew.UseVisualStyleBackColor = true;
           this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
           // 
           // btnOrder
           // 
           this.btnOrder.Enabled = false;
           this.btnOrder.Location = new System.Drawing.Point(124, 123);
           this.btnOrder.Margin = new System.Windows.Forms.Padding(4);
           this.btnOrder.Name = "btnOrder";
           this.btnOrder.Size = new System.Drawing.Size(100, 28);
           this.btnOrder.TabIndex = 10;
           this.btnOrder.Text = "Order";
           this.btnOrder.UseVisualStyleBackColor = true;
           this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
           // 
           // btnRefund
           // 
           this.btnRefund.Enabled = false;
           this.btnRefund.Location = new System.Drawing.Point(232, 123);
           this.btnRefund.Margin = new System.Windows.Forms.Padding(4);
           this.btnRefund.Name = "btnRefund";
           this.btnRefund.Size = new System.Drawing.Size(100, 28);
           this.btnRefund.TabIndex = 11;
           this.btnRefund.Text = "Refund";
           this.btnRefund.UseVisualStyleBackColor = true;
           this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
           // 
           // lvOrder
           // 
           this.lvOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cbItem,
            this.cbQuantity});
           this.lvOrder.Location = new System.Drawing.Point(340, 15);
           this.lvOrder.Margin = new System.Windows.Forms.Padding(4);
           this.lvOrder.Name = "lvOrder";
           this.lvOrder.Size = new System.Drawing.Size(479, 136);
           this.lvOrder.TabIndex = 8;
           this.lvOrder.UseCompatibleStateImageBehavior = false;
           this.lvOrder.View = System.Windows.Forms.View.Details;
           this.lvOrder.SelectedIndexChanged += new System.EventHandler(this.lvOrder_SelectedIndexChanged);
           // 
           // cbItem
           // 
           this.cbItem.Text = "Item";
           this.cbItem.Width = 271;
           // 
           // cbQuantity
           // 
           this.cbQuantity.Text = "Quantity";
           this.cbQuantity.Width = 63;
           // 
           // OrderForm
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(831, 161);
           this.Controls.Add(this.lvOrder);
           this.Controls.Add(this.btnRefund);
           this.Controls.Add(this.btnOrder);
           this.Controls.Add(this.btnNew);
           this.Controls.Add(this.gbOrder);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
           this.Margin = new System.Windows.Forms.Padding(4);
           this.Name = "OrderForm";
           this.Text = "Order Form";
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OrderForm_FormClosing);
           this.gbOrder.ResumeLayout(false);
           this.gbOrder.PerformLayout();
           ((System.ComponentModel.ISupportInitialize)(this.udQuantity)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOrder;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown udQuantity;
        private System.Windows.Forms.ComboBox comboProduct;
        private System.Windows.Forms.ListView lvOrder;
        private System.Windows.Forms.ColumnHeader cbItem;
        private System.Windows.Forms.ColumnHeader cbQuantity;

    }
}