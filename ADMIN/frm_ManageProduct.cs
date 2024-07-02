using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_and_Inventory_Management_System.ADMIN
{
    public partial class frm_ManageProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;

       
        private DateTime AddDays;
        private DateTime expirationDate;
        public frm_ManageProduct()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            //LoadCategory();
            //DateTime warningDate= new DateTime();
            //if(warningDate<=DateTime.Today)
            //{
            //    string message = "Warning:Product expires in 30 days or less!";
            //    string caption = "Expiration Warning";
            //    MessageBoxButtons buttons = MessageBoxButtons.OK;
            //    MessageBoxIcon icon = MessageBoxIcon.Warning;
            //    MessageBox.Show(message, caption, buttons, icon);
                
            //  //  MessageBox.Show("Warning: Product expires in 30 days or less!", "Expiration Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                   
            //}
           
         LoadProduct();

        }

 
        
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Category_Click(object sender, EventArgs e)
        {
            //frm_AddCategory frm = new frm_AddCategory(this);
            //frm.ShowDialog();
        }

       
       

        private void txt_ProductCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
           
        }

        public void LoadProduct()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
              
                cn.Open();
                cm = new SqlCommand("select PCode,ProductDate, ProductName,Category,CostPrice,Qty,Profit,SalesPrice, Tax,TotalPrice,StockInQty,Barcode,ExpiringDate from tblProduct where PCode like '%" + txt_Search.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    DateTime Expirigdate = Convert.ToDateTime(dr["ExpiringDate"]);
                    string ProdExpirigdate = Expirigdate.ToString("dd/MM/yyyy");

                    // Parse the FDate column as a DateTime object
                    DateTime fDate = Convert.ToDateTime(dr["ProductDate"]);
                    // Format the date as dd/MM/yyyy
                    string formattedFDate = fDate.ToString("dd/MM/yyyy");

                    dataGridView1.Rows.Add(i, dr[0].ToString(), formattedFDate, dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString(), ProdExpirigdate);
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbo_Tax_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    decimal salesPrice = decimal.Parse(txt_SalesPrice.Text);
            //    decimal tax = decimal.Parse(cbo_Tax.Text);
            //    decimal total = (salesPrice * tax / 100) + salesPrice;
            //    txt_TotalPrice.Text = total.ToString("#,##0.00");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void frm_ManageProduct_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 30;
           
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblProduct where PCode like '%" + txt_Search.Text + "%'or ProductName like '%" + txt_Search.Text + "%'or Category like'%" + txt_Search.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;

                    // Parse the FDate column as a DateTime object
                    DateTime fDate = Convert.ToDateTime(dr["ProductDate"]);
                    // Format the date as dd/MM/yyyy
                    string formattedFDate = fDate.ToString("dd/MM/yyyy");
                    dataGridView1.Rows.Add(i, dr["PCode"].ToString(), formattedFDate, dr["ProductName"].ToString(), dr["Category"].ToString(), dr["CostPrice"].ToString(), dr["Qty"].ToString(), dr["Profit"].ToString(), dr["SalesPrice"].ToString(), dr["Tax"].ToString(), dr["TotalPrice"].ToString(), dr["StockInQty"].ToString(), dr["Barcode"].ToString(), dr["ExpiringDate"].ToString());
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                cn.Close();
                throw ex;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frm_ProductEnteryForm frm = new frm_ProductEnteryForm(this);
            frm.btn_Save.Enabled = true;
            frm.btn_Update.Enabled = false;
            LoadProduct();
            frm.Show();
        }

        private void cbo_Category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (ColName == "Edit")
            {
                frm_ProductEnteryForm frm = new frm_ProductEnteryForm(this);
                frm.btn_Update.Enabled = true;
                frm.btn_Save.Enabled = false;
                frm.lblProductId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                frm.txt_ProductCode.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.dtProductDate.CustomFormat = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txt_Productname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.cbo_Category.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.txt_CostPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frm.txt_Qty.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.Profit = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                frm.txt_SalesPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                frm.cbo_Tax.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                frm.txt_TotalPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                frm.txt_Barcode.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                frm.dtExpiringDate.CustomFormat = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                frm.Show();
                LoadProduct();
            }
            else if (ColName == "Delete")
            {
                if (MessageBox.Show("DELETE THIS RECORD? CLICK YES TO CONFIRM", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblProduct where ProductId like '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("The Record has been successfully deleted.");
                    LoadProduct();
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}