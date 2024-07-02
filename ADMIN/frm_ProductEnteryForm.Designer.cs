namespace POS_and_Inventory_Management_System.ADMIN
{
    partial class frm_ProductEnteryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ProductEnteryForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_CLEAR = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_CostPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtProductDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_Category = new System.Windows.Forms.ComboBox();
            this.txt_Productname = new System.Windows.Forms.TextBox();
            this.txt_ProductCode = new System.Windows.Forms.TextBox();
            this.btn_Category = new System.Windows.Forms.Button();
            this.txt_Barcode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_Tax = new System.Windows.Forms.ComboBox();
            this.txt_TotalPrice = new System.Windows.Forms.TextBox();
            this.txt_SalesPrice = new System.Windows.Forms.TextBox();
            this.lblProductId = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.dtExpiringDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 38);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(174, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "MANAGE PRODUCT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(468, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.btn_CLEAR);
            this.panel2.Controls.Add(this.btn_Update);
            this.panel2.Controls.Add(this.btn_Save);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 398);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 50);
            this.panel2.TabIndex = 1;
            // 
            // btn_CLEAR
            // 
            this.btn_CLEAR.BackColor = System.Drawing.Color.Maroon;
            this.btn_CLEAR.FlatAppearance.BorderSize = 0;
            this.btn_CLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CLEAR.ForeColor = System.Drawing.Color.White;
            this.btn_CLEAR.Location = new System.Drawing.Point(373, 2);
            this.btn_CLEAR.Name = "btn_CLEAR";
            this.btn_CLEAR.Size = new System.Drawing.Size(129, 46);
            this.btn_CLEAR.TabIndex = 33;
            this.btn_CLEAR.Text = "CLEAR";
            this.btn_CLEAR.UseVisualStyleBackColor = false;
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.Gray;
            this.btn_Update.FlatAppearance.BorderSize = 0;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Location = new System.Drawing.Point(188, 2);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(129, 44);
            this.btn_Update.TabIndex = 32;
            this.btn_Update.Text = "UPDATE";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(6, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(129, 44);
            this.btn_Save.TabIndex = 31;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_CostPrice
            // 
            this.txt_CostPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CostPrice.Location = new System.Drawing.Point(7, 328);
            this.txt_CostPrice.Name = "txt_CostPrice";
            this.txt_CostPrice.Size = new System.Drawing.Size(223, 33);
            this.txt_CostPrice.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 21);
            this.label10.TabIndex = 34;
            this.label10.Text = "Product name";
            // 
            // dtProductDate
            // 
            this.dtProductDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtProductDate.Location = new System.Drawing.Point(10, 146);
            this.dtProductDate.Name = "dtProductDate";
            this.dtProductDate.Size = new System.Drawing.Size(220, 29);
            this.dtProductDate.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "Cost Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 31;
            this.label3.Text = "Category";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 21);
            this.label2.TabIndex = 30;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 29;
            this.label1.Text = "Product Code";
            // 
            // cbo_Category
            // 
            this.cbo_Category.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Category.FormattingEnabled = true;
            this.cbo_Category.Location = new System.Drawing.Point(7, 267);
            this.cbo_Category.Name = "cbo_Category";
            this.cbo_Category.Size = new System.Drawing.Size(223, 33);
            this.cbo_Category.TabIndex = 28;
            this.cbo_Category.SelectedIndexChanged += new System.EventHandler(this.cbo_Category_SelectedIndexChanged);
            // 
            // txt_Productname
            // 
            this.txt_Productname.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Productname.Location = new System.Drawing.Point(7, 204);
            this.txt_Productname.Name = "txt_Productname";
            this.txt_Productname.Size = new System.Drawing.Size(223, 33);
            this.txt_Productname.TabIndex = 27;
            // 
            // txt_ProductCode
            // 
            this.txt_ProductCode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProductCode.Location = new System.Drawing.Point(7, 83);
            this.txt_ProductCode.Name = "txt_ProductCode";
            this.txt_ProductCode.Size = new System.Drawing.Size(223, 33);
            this.txt_ProductCode.TabIndex = 26;
            // 
            // btn_Category
            // 
            this.btn_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Category.FlatAppearance.BorderSize = 0;
            this.btn_Category.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Category.ForeColor = System.Drawing.Color.White;
            this.btn_Category.Location = new System.Drawing.Point(236, 268);
            this.btn_Category.Name = "btn_Category";
            this.btn_Category.Size = new System.Drawing.Size(36, 28);
            this.btn_Category.TabIndex = 36;
            this.btn_Category.Text = "+";
            this.btn_Category.UseVisualStyleBackColor = false;
            this.btn_Category.Click += new System.EventHandler(this.btn_Category_Click);
            // 
            // txt_Barcode
            // 
            this.txt_Barcode.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Barcode.Location = new System.Drawing.Point(280, 324);
            this.txt_Barcode.Name = "txt_Barcode";
            this.txt_Barcode.Size = new System.Drawing.Size(233, 33);
            this.txt_Barcode.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 21);
            this.label9.TabIndex = 43;
            this.label9.Text = "Barcode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 21);
            this.label7.TabIndex = 42;
            this.label7.Text = "Total Price";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(276, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 21);
            this.label6.TabIndex = 41;
            this.label6.Text = "Tax %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 40;
            this.label5.Text = "Sales Price";
            // 
            // cbo_Tax
            // 
            this.cbo_Tax.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Tax.FormattingEnabled = true;
            this.cbo_Tax.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cbo_Tax.Location = new System.Drawing.Point(278, 203);
            this.cbo_Tax.Name = "cbo_Tax";
            this.cbo_Tax.Size = new System.Drawing.Size(236, 33);
            this.cbo_Tax.TabIndex = 39;
            this.cbo_Tax.SelectedIndexChanged += new System.EventHandler(this.cbo_Tax_SelectedIndexChanged);
            // 
            // txt_TotalPrice
            // 
            this.txt_TotalPrice.Enabled = false;
            this.txt_TotalPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalPrice.Location = new System.Drawing.Point(277, 265);
            this.txt_TotalPrice.Name = "txt_TotalPrice";
            this.txt_TotalPrice.Size = new System.Drawing.Size(237, 33);
            this.txt_TotalPrice.TabIndex = 38;
            // 
            // txt_SalesPrice
            // 
            this.txt_SalesPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SalesPrice.Location = new System.Drawing.Point(280, 140);
            this.txt_SalesPrice.Name = "txt_SalesPrice";
            this.txt_SalesPrice.Size = new System.Drawing.Size(234, 33);
            this.txt_SalesPrice.TabIndex = 37;
            // 
            // lblProductId
            // 
            this.lblProductId.AutoSize = true;
            this.lblProductId.Location = new System.Drawing.Point(104, 41);
            this.lblProductId.Name = "lblProductId";
            this.lblProductId.Size = new System.Drawing.Size(0, 21);
            this.lblProductId.TabIndex = 45;
            this.lblProductId.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(276, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 21);
            this.label11.TabIndex = 47;
            this.label11.Text = "Quantity";
            // 
            // txt_Qty
            // 
            this.txt_Qty.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Qty.Location = new System.Drawing.Point(280, 83);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Size = new System.Drawing.Size(234, 33);
            this.txt_Qty.TabIndex = 46;
            // 
            // dtExpiringDate
            // 
            this.dtExpiringDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExpiringDate.Location = new System.Drawing.Point(117, 365);
            this.dtExpiringDate.Name = "dtExpiringDate";
            this.dtExpiringDate.Size = new System.Drawing.Size(392, 29);
            this.dtExpiringDate.TabIndex = 49;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 371);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 21);
            this.label12.TabIndex = 48;
            this.label12.Text = "Expiring Date";
            // 
            // frm_ProductEnteryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(514, 448);
            this.ControlBox = false;
            this.Controls.Add(this.dtExpiringDate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.lblProductId);
            this.Controls.Add(this.txt_Barcode);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbo_Tax);
            this.Controls.Add(this.txt_TotalPrice);
            this.Controls.Add(this.txt_SalesPrice);
            this.Controls.Add(this.btn_Category);
            this.Controls.Add(this.txt_CostPrice);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtProductDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_Category);
            this.Controls.Add(this.txt_Productname);
            this.Controls.Add(this.txt_ProductCode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_ProductEnteryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Category;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_CLEAR;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btn_Update;
        public System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblProductId;
        public System.Windows.Forms.TextBox txt_ProductCode;
        public System.Windows.Forms.DateTimePicker dtProductDate;
        public System.Windows.Forms.TextBox txt_Productname;
        public System.Windows.Forms.ComboBox cbo_Category;
        public System.Windows.Forms.TextBox txt_CostPrice;
        public System.Windows.Forms.TextBox txt_SalesPrice;
        public System.Windows.Forms.ComboBox cbo_Tax;
        public System.Windows.Forms.TextBox txt_TotalPrice;
        public System.Windows.Forms.TextBox txt_Barcode;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txt_Qty;
        public System.Windows.Forms.DateTimePicker dtExpiringDate;
        private System.Windows.Forms.Label label12;
    }
}