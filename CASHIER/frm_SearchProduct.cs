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
    public partial class frm_SearchProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;
        frm_mainCashier flist;
        public frm_SearchProduct(frm_mainCashier fm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            this.flist = fm;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadProduct()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select PCode,ProductName,Category,SalesPrice,Tax,TotalPrice,Barcode from tblProduct where ProductName like '%" + txt_SearchProduct.Text + "%'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ColName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (ColName == "ColSelect")
            {
               
                frm_mainCashier frm = new frm_mainCashier();
                //frm.(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(), int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()));
                frm.ShowDialog();
            }

        }

        private void frm_SearchProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void txt_SearchProduct_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from tblProduct where PCode like '%" + txt_SearchProduct.Text + "%'or ProductName like '%" + txt_SearchProduct.Text + "%'or Category like'%" + txt_SearchProduct.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;


                    dataGridView1.Rows.Add(i, dr["PCode"].ToString(), dr["ProductName"].ToString(), dr["Category"].ToString(), dr["Tax"].ToString(), dr["SalesPrice"].ToString(), dr["Barcode"].ToString());
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
    }
}
