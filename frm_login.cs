using POS_and_Inventory_Management_System.ADMIN;
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


namespace POS_and_Inventory_Management_System
{
    public partial class frm_login : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;  
        
        public string _pass,  _username="";
        public bool _isactive = false;
        public frm_login()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Please confirm if you want to exit the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string _role = "", _name = "";
            try
            {
                bool found = false;
                cn.Open();
                cm = new SqlCommand("select * from tblUser where UserName=@UserName and Password=@Password", cn);
                cm.Parameters.AddWithValue("@UserName", txt_username.Text);
                cm.Parameters.AddWithValue("@Password", txt_password.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    found = true;
                    _username = dr["username"].ToString();
                    _role = dr["role"].ToString();
                    _name = dr["name"].ToString();
                    _pass = dr["password"].ToString();                   
                }
                else
                {
                    found = false;
                    _username = "";
                    _role = "";
                    _name = "";
                    _pass = "";
                }
                dr.Close();
                cn.Close();
                if (found == true)
                {
                                     
                    if (_role == "Cashier")
                    {
                        MessageBox.Show(" Welcome" + _name + "!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_username.Clear();
                        txt_password.Clear();
                        this.Hide();
                       frm_mainCashier fm = new frm_mainCashier();
                       fm.lblUser.Text = _username;                       
                       fm.lblName.Text = _name + "|" + _role;
                        fm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(" Welcome" + _name + "!", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_username.Clear();
                        txt_password.Clear();
                        this.Hide();
                        frm_mainAdmin fm = new frm_mainAdmin();
                        fm.lblName.Text = _name;
                        fm.lblUser.Text = _username;
                        fm.lblRole.Text = _role;
                        fm._pass = _pass;
                        fm._user = _username;
                        //fm.LoadDashboard();
                        fm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
