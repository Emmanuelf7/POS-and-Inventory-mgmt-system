using POS_and_Inventory_Management_System.CASHIER;
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
using Tulpep.NotificationWindow;
namespace POS_and_Inventory_Management_System.ADMIN
{
    public partial class frm_mainAdmin : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        public string _pass, _user;
        SqlDataReader dr;
        public frm_mainAdmin()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            NotifyExpiringProduct();
            LoadDashboard(); 
        }

       

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            frm_ManageProduct frm = new frm_ManageProduct();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.LoadProduct();
            frm.Show();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            frm_ManageUser frm = new frm_ManageUser();
            frm.Show();
        }

        private void btnManageStock_Click(object sender, EventArgs e)
        {
            frm_ManageStock frm = new frm_ManageStock();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
            frm.LoadProduct();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
                     
            if (MessageBox.Show("LOGOUT THE APPLICATION ?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frm_login frm = new frm_login();
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frm_Dashboard frm = new frm_mainCashier();
            //frm.TopLevel = false;
            //panel4.Controls.Add(frm);
            //frm.BringToFront();
            //frm.Show();

            LoadDashboard();
        }

        public void NotifyExpiringProduct()
        {
            string expiring = "";
            cn.Open();
            cm = new SqlCommand("select count(*) as ExpiringProductCount from tblProduct where ExpiringDate <= DATEADD(day,30, GETDATE())", cn);
            string count = cm.ExecuteScalar().ToString();
            cn.Close();

            int i = 0;
            cn.Open();
           // cm = new SqlCommand("select * from tblProduct", cn);
            cm = new SqlCommand("select * from tblProduct where ExpiringDate <= DATEADD(day,30, GETDATE())", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                expiring += i + "." + dr["ProductName"].ToString() + Environment.NewLine;
                
            }
            dr.Close();
            cn.Close();

            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.close_button_icon;
            popup.TitleText = count + "Product(s) Will Soon Expire";
            popup.ContentText = expiring;
            popup.Popup();
        }
        public void LoadDashboard()
        {
            frm_Dashboard frm = new frm_Dashboard();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.lblDailySales.Text = dbcon.DailySales().ToString("GHC#,##0.00");
            frm.lblProductLine.Text = dbcon.ProductLine().ToString("#,##0");
            frm.lblStockOnHand.Text = dbcon.StockOnHand().ToString("#,##0");
            frm.lblCritical.Text = dbcon.CriticalItems().ToString("#,##0");
            frm.lblDisplayExpiringProduct.Text = dbcon.ExpiringProduct().ToString("0");
            frm.Show();
        }
        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {

        }

        private void btn_SalesHistory_Click(object sender, EventArgs e)
        {
            frm_SalesReport frm = new frm_SalesReport();
            frm.TopLevel = false;
            panel4.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }
    }
}
