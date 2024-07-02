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

namespace POS_and_Inventory_Management_System.CASHIER
{
    public partial class frm_SalesReport : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;
        public string suser;
        public frm_SalesReport()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            dt1.Value = DateTime.Now;
            dt2.Value = DateTime.Now;
            LoadSalesReport();
            LoadCashier();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frm_PrintSalesReport frm = new frm_PrintSalesReport(this);
            frm.LoadReport();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadSalesReport()
        {
            int i = 0;
            double _total = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            if (cboCashier.Text == "All Cashier")
            {
                cm = new SqlCommand("select TransactionDate,ProductCode, TransactionNo,  ProductName, category,price, totaltax,qty,totalPriceqty,discount,grandTotal,payMode from tblSales where TransactionDate between'" + dt1.Value.ToString("yyyy-MM-dd") + "' and'" + dt2.Value.ToString("yyyy-MM-dd") + "'", cn);
            }
            else
            {
                cm = new SqlCommand("select TransactionDate,ProductCode, TransactionNo, ProductName, category,price, totaltax,qty,totalPriceqty,discount,grandTotal,payMode from tblSales where TransactionDate between'" + dt1.Value.ToString("yyyy-MM-dd") + "' and'" + dt2.Value.ToString("yyyy-MM-dd") + "'and cashier like '" + cboCashier.Text + "'", cn);
            }
            dr = cm.ExecuteReader();

            while (dr.Read())
            {
                i += 1;
                // Parse the FDate column as a DateTime object
                DateTime fDate = Convert.ToDateTime(dr["TransactionDate"]);
                // Format the date as dd/MM/yyyy
                string formattedFDate = fDate.ToString("dd/MM/yyyy");
                _total += double.Parse(dr["totalPriceqty"].ToString());
                dataGridView1.Rows.Add(i, formattedFDate, dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString());
            }
            dr.Close();
            cn.Close();
            lblTotal.Text = _total.ToString("#,##0.00");
          
        }




        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("All Cashier");
            cn.Open();
            cm = new SqlCommand("select * from tblUser where Role like 'Cashier'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboCashier.Items.Add(dr["UserName"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void cboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void dt2_ValueChanged(object sender, EventArgs e)
        {
            LoadSalesReport();
        }

        private void cboCashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
