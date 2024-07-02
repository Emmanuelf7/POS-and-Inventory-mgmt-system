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
    public partial class frm_ManageStock : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;
        string stitle = "POS System";
        public frm_ManageStock()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void frm_ManageStock_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 30;
        }

        public void LoadProduct()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select PCode,ProductDate, ProductName,Category,CostPrice,Profit,SalesPrice, Tax,TotalPrice,Qty,StockInQty,Barcode from tblProduct where PCode like '%" + txt_Search.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // Parse the FDate column as a DateTime object
                    DateTime fDate = Convert.ToDateTime(dr["ProductDate"]);
                    // Format the date as dd/MM/yyyy
                    string formattedFDate = fDate.ToString("dd/MM/yyyy");

                    dataGridView1.Rows.Add(i, dr[0].ToString(), formattedFDate, dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString());
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

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select PCode,ProductDate, ProductName,Category,CostPrice,Profit,SalesPrice, Tax,TotalPrice,Qty,StockInQty,Barcode from tblProduct where PCode like '%" + txt_Search.Text + "%' or ProductName like '%" + txt_Search.Text + "%' or Category like'%" + txt_Search.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    // Parse the FDate column as a DateTime object
                    DateTime fDate = Convert.ToDateTime(dr["ProductDate"]);
                    // Format the date as dd/MM/yyyy
                    string formattedFDate = fDate.ToString("dd/MM/yyyy");

                    dataGridView1.Rows.Add(i, dr[0].ToString(), formattedFDate, dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString(), dr[11].ToString());
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

        private void btn_UpdateStock_Click(object sender, EventArgs e)
        {
           try
            {
                if(dataGridView1.Rows.Count > 0)
                {
                    
                        // update product qty
                        if(MessageBox.Show("Please confirm if you want to save this record?",stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                            cn.Open();
                            //cm = new SqlCommand("update tblProduct set StockIn = StockIn + " + int.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString()) + "where PCode like'" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'", cn);
                            cm = new SqlCommand("update tblProduct set StockInQty = @StockInQty WHERE PCode=@PCode  ", cn);
                            cm.Parameters.AddWithValue("@StockInQty", int.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString()));                           
                            cm.Parameters.AddWithValue("@PCode",dataGridView1.Rows[i].Cells[1].Value.ToString());
                            cm.ExecuteNonQuery();
                            cn.Close();
                            // update tblStockIn
                            //cn.Open();
                            //cm = new SqlCommand("update tblStockIn set StockIn = StockIn + " + int.Parse(dataGridView1.Rows[i].Cells[10].Value.ToString()) + ", status = 'Done' where id like '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'", cn);
                            //cm.ExecuteNonQuery();
                            //cn.Close();
                          //   MessageBox.Show("Stock in has been successfully updated");
                        }
                       // Clear();
                            LoadProduct();
                        
                    }
                }
            }catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

