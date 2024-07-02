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
    public partial class frm_ManageUser : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;


        public frm_ManageUser()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void Clear()
        {

            txt_name.Clear();
            txt_username.Clear();
            txt_password.Clear();
            cbo_role.SelectedIndex = -1;
            txt_name.Focus();
        }
        private void frm_ManageUser_Load(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Please confirm if you want to create a new user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblUser(Name,UserName,Password,Role)VALUES(@Name,@UserName,@Password,@Role)", cn);
                    cm.Parameters.AddWithValue("@Name", txt_name.Text);
                    cm.Parameters.AddWithValue("@UserName", txt_username.Text);
                    cm.Parameters.AddWithValue("@Password", txt_password.Text);
                    cm.Parameters.AddWithValue("@Role", cbo_role.SelectedItem);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("New user has been successfully created!", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                   // flist.LoadBrandRecord();
                    this.Dispose();
                }

            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            frm_mainAdmin frm = new frm_mainAdmin();
            frm.Show();
        }
    }
}
