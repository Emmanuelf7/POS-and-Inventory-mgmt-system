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
    public partial class frm_Discount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;
        frm_mainCashier flist;
        public frm_Discount(frm_mainCashier fm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            this.flist = fm;
        }

        private void frm_Discount_Load(object sender, EventArgs e)
        {

        }

        private void btn_Updatediscount_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("update tblDiscount set Discount=@Discount ", cn);
                cm.Parameters.AddWithValue("@Discount", txt_discount.Text);
                cm.Parameters.AddWithValue("@DiscountId", lblDiscountID.Text); 
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Discount has been successfully updated!", "Discount updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flist.LoadDiscount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
