using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_and_Inventory_Management_System.ADMIN
{
    public partial class frm_ProductEnteryForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;
        frm_ManageProduct f;
        public decimal Profit = 0;
        public frm_ProductEnteryForm(frm_ManageProduct fm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            this.f = fm;
            LoadCategory();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Category_Click(object sender, EventArgs e)
        {
            frm_AddCategory frm = new frm_AddCategory(this);
            frm.Show();
        }

        public void LoadCategory()
        {
            cbo_Category.Items.Clear();
            try
            {
                int i = 0;
                // dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblCategory", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;

                    cbo_Category.Items.Add(dr["CategoryName"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                dr.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void cbo_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                decimal salesPrice;
                decimal tax;

                if (decimal.TryParse(txt_SalesPrice.Text, out salesPrice) &&
                    decimal.TryParse(cbo_Tax.Text, out tax))
                {
                    decimal total = (salesPrice * tax / 100) + salesPrice;
                    txt_TotalPrice.Text = total.ToString("#,##0.00");
                }
                else
                {
                    MessageBox.Show("Sales Price and Tax must be numeric values.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Clear()
        {
            txt_ProductCode.Clear();
            txt_Productname.Clear();
            cbo_Category.SelectedIndex = -1;
            txt_CostPrice.Clear();
            txt_SalesPrice.Clear();          
            txt_Qty.Clear();
            txt_Barcode.Clear();
            txt_TotalPrice.Clear();         
            btn_Save.Enabled = true;
            btn_Update.Enabled = false;


        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            //if (txt_Productname.Text == "" || txt_CostPrice.Text == "" || txt_SalesPrice.Text == "")
            //{
            //    MessageBox.Show("Missing Information !!!");
            //}
            //else
            //{

            //    try
            //    {
            //        if (MessageBox.Show("Please confirm if you want to save this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            decimal Profit = Convert.ToDecimal(txt_SalesPrice.Text) - Convert.ToDecimal(txt_CostPrice.Text);
            //            cn.Open();
            //            cm = new SqlCommand("INSERT INTO tblProduct(PCode,ProductDate,ProductName, Category, CostPrice,Profit,SalesPrice,Tax,TotalPrice,Barcode)VALUES(@pCode,@productDate,@productName, @category, @costPrice,@profit,@salesPrice,@tax,@totalPrice,@barcode)", cn);
            //            cm.Parameters.AddWithValue("@pCode", txt_ProductCode.Text);
            //            cm.Parameters.AddWithValue("@productDate", DbType.Date).Value = dtProductDate.Value;
            //            cm.Parameters.AddWithValue("@productName", txt_Productname.Text);
            //            cm.Parameters.AddWithValue("@category", cbo_Category.Text);
            //            cm.Parameters.AddWithValue("@costPrice", txt_CostPrice.Text);
            //            cm.Parameters.AddWithValue("@profit", Profit);
            //            cm.Parameters.AddWithValue("@salesPrice", txt_SalesPrice.Text);
            //            cm.Parameters.AddWithValue("@tax", cbo_Tax.Text);
            //            cm.Parameters.AddWithValue("@totalPrice", txt_TotalPrice.Text);
            //            // cm.Parameters.AddWithValue("@stockIn", txt_Stock.Text);
            //            cm.Parameters.AddWithValue("@barcode", txt_Barcode.Text);
            //            cm.ExecuteNonQuery();
            //            cn.Close();
            //            MessageBox.Show("Product has been successfully saved!", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            Clear();
            //            f.LoadProduct();


            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        cn.Close();
            //        MessageBox.Show(ex.Message);
            //    }
           // }
           
       
    if (string.IsNullOrWhiteSpace(txt_Productname.Text) ||
        string.IsNullOrWhiteSpace(txt_Qty.Text) ||
        string.IsNullOrWhiteSpace(txt_CostPrice.Text) ||
        string.IsNullOrWhiteSpace(txt_SalesPrice.Text))
       
    {
        MessageBox.Show("Missing Information !!!");
        return;
    }

    decimal costPrice;
    decimal salesPrice;

    if (!decimal.TryParse(txt_CostPrice.Text, out costPrice) ||
        !decimal.TryParse(txt_SalesPrice.Text, out salesPrice))
    {
        MessageBox.Show("Cost Price and Sales Price must be numeric values.");
        return;
    }

    decimal profit = salesPrice - costPrice;

    try
    {
        if (MessageBox.Show("Please confirm if you want to save this product?",
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            cn.Open();
            cm = new SqlCommand("INSERT INTO tblProduct(PCode,ProductDate,ProductName, Category, CostPrice,Qty,Profit,SalesPrice,Tax,TotalPrice,Barcode,ExpiringDate) " +
                "VALUES(@pCode,@productDate,@productName, @category, @costPrice,@qty, @profit,@salesPrice,@tax,@totalPrice,@barcode,@ExpiringDate)", cn);
            cm.Parameters.AddWithValue("@pCode", txt_ProductCode.Text);
            cm.Parameters.AddWithValue("@productDate", dtProductDate.Value);
            cm.Parameters.AddWithValue("@productName", txt_Productname.Text);
            cm.Parameters.AddWithValue("@category", cbo_Category.Text);
            cm.Parameters.AddWithValue("@costPrice", costPrice);
            cm.Parameters.AddWithValue("@ExpiringDate", dtExpiringDate.Value);
            int qty;
            if (!int.TryParse(txt_Qty.Text, out qty))
            {
                MessageBox.Show("quantity must be a numeric value.");
                cn.Close();
                return;
            }
            cm.Parameters.AddWithValue("@qty", txt_Qty.Text);

            cm.Parameters.AddWithValue("@profit", profit);
            cm.Parameters.AddWithValue("@salesPrice", salesPrice);

            decimal tax;
            if (!decimal.TryParse(cbo_Tax.Text, out tax))
            {
                MessageBox.Show("Tax must be a numeric value.");
                cn.Close();
                return;
            }

            cm.Parameters.AddWithValue("@tax", tax);

            decimal totalPrice;
            if (!decimal.TryParse(txt_TotalPrice.Text, out totalPrice))
            {
                MessageBox.Show("Total Price must be a numeric value.");
                cn.Close();
                return;
            }

            cm.Parameters.AddWithValue("@totalPrice", totalPrice);
            cm.Parameters.AddWithValue("@barcode", txt_Barcode.Text);
            cm.ExecuteNonQuery();
            cn.Close();

            MessageBox.Show("Product has been successfully saved!", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
             LoadCategory();
             f.LoadProduct();
        }
    }
    catch (Exception ex)
    {
        cn.Close();
        MessageBox.Show(ex.Message);
    }
}
    
        

        private void btn_Update_Click(object sender, EventArgs e)
        {
           
                try
                {
                    if (MessageBox.Show("Please confirm if you want to update this product?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        decimal Profit = Convert.ToDecimal(txt_SalesPrice.Text) - Convert.ToDecimal(txt_CostPrice.Text);
                        cn.Open();
                        cm = new SqlCommand("UPDATE tblProduct SET ProductDate=@ProductDate,ProductName=@ProductName,Category=@Category, CostPrice=@CostPrice,Qty=@Qty,Profit=@Profit,SalesPrice=@SalesPrice,Tax=@Tax,TotalPrice=@TotalPrice,Barcode=@Barcode,ExpiringDate=@ExpiringDate where PCode like @PCode ", cn);
                        cm.Parameters.AddWithValue("@PCode", txt_ProductCode.Text);
                        cm.Parameters.AddWithValue("@ProductDate", DbType.Date).Value = dtProductDate.Value;
                        cm.Parameters.AddWithValue("@ProductName", txt_Productname.Text);
                        cm.Parameters.AddWithValue("@Category", cbo_Category.Text);
                        cm.Parameters.AddWithValue("@CostPrice", decimal.Parse(txt_CostPrice.Text));
                        cm.Parameters.AddWithValue("@Qty", int.Parse(txt_Qty.Text));
                        cm.Parameters.AddWithValue("@Profit", Profit);
                        cm.Parameters.AddWithValue("@SalesPrice", txt_SalesPrice.Text);
                        cm.Parameters.AddWithValue("@Tax", decimal.Parse(cbo_Tax.Text));
                        cm.Parameters.AddWithValue("@TotalPrice", decimal.Parse(txt_TotalPrice.Text));                      
                        cm.Parameters.AddWithValue("@Barcode", txt_Barcode.Text);
                        cm.Parameters.AddWithValue("@ExpiringDate", dtExpiringDate.Value);
                        cm.Parameters.AddWithValue("@ProductId", lblProductId.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successfully updated!", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        f.LoadProduct();


                    }
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        

        private void cbo_Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
