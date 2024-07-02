namespace POS_and_Inventory_Management_System.CASHIER
{
    partial class frm_Discount
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
            this.txt_discount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Updatediscount = new System.Windows.Forms.Button();
            this.lblDiscountID = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_discount
            // 
            this.txt_discount.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_discount.Location = new System.Drawing.Point(12, 26);
            this.txt_discount.Name = "txt_discount";
            this.txt_discount.Size = new System.Drawing.Size(293, 29);
            this.txt_discount.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Discount %";
            // 
            // btn_Updatediscount
            // 
            this.btn_Updatediscount.BackColor = System.Drawing.Color.Gray;
            this.btn_Updatediscount.FlatAppearance.BorderSize = 0;
            this.btn_Updatediscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Updatediscount.ForeColor = System.Drawing.Color.White;
            this.btn_Updatediscount.Location = new System.Drawing.Point(12, 69);
            this.btn_Updatediscount.Name = "btn_Updatediscount";
            this.btn_Updatediscount.Size = new System.Drawing.Size(293, 44);
            this.btn_Updatediscount.TabIndex = 33;
            this.btn_Updatediscount.Text = "UPDATE DISCOUNT";
            this.btn_Updatediscount.UseVisualStyleBackColor = false;
            this.btn_Updatediscount.Click += new System.EventHandler(this.btn_Updatediscount_Click);
            // 
            // lblDiscountID
            // 
            this.lblDiscountID.AutoSize = true;
            this.lblDiscountID.Location = new System.Drawing.Point(159, 5);
            this.lblDiscountID.Name = "lblDiscountID";
            this.lblDiscountID.Size = new System.Drawing.Size(0, 17);
            this.lblDiscountID.TabIndex = 34;
            this.lblDiscountID.Visible = false;
            // 
            // frm_Discount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(317, 114);
            this.Controls.Add(this.lblDiscountID);
            this.Controls.Add(this.btn_Updatediscount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_discount);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_Discount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Discount";
            this.Load += new System.EventHandler(this.frm_Discount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_discount;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btn_Updatediscount;
        public System.Windows.Forms.Label lblDiscountID;
    }
}