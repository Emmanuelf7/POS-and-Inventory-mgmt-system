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

namespace POS_and_Inventory_Management_System.ADMIN
{
    public partial class frm_ChangePassword : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;
        frm_mainCashier f;
        public frm_ChangePassword(frm_mainCashier fm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            this.f = fm;
        }

        private void btn_changePassword_Click(object sender, EventArgs e)
        {
            try
            {
                //if (txt_oldPassword.Text != f._pass)
                //{
                //    MessageBox.Show("Old password did not match!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;

                //}
                if (txt_oldPassword.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Old password is required?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    txt_oldPassword.Focus();
                    return;
                }
                if (txt_newPassword.Text != txt_repeatOldpassword.Text)
                {
                    MessageBox.Show("Confirm new password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                cn.Open();
                cm = new SqlCommand("update tblUser set Password=@Password where Password=@Password1", cn);
                cm.Parameters.AddWithValue("@Password", txt_repeatOldpassword.Text);
                cm.Parameters.AddWithValue("@Password1", txt_oldPassword.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Password has been successfully changed!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_newPassword.Clear();
                txt_oldPassword.Clear();
                txt_repeatOldpassword.Clear();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
    }
}
