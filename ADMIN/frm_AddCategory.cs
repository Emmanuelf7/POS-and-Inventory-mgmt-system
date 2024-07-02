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
    public partial class frm_AddCategory : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        frm_ProductEnteryForm fm;
        public frm_AddCategory(frm_ProductEnteryForm f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            this.fm = f;
        }

        private void Clear()
        {
            txt_Category.Clear();
            txt_Category.Focus();
            return;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Please confirm if you want to save this category?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("INSERT INTO tblCategory(CategoryName)VALUES(@CategoryName)", cn);
                    cm.Parameters.AddWithValue("@CategoryName", txt_Category.Text);                   
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Category has been successfully saved!", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    fm.LoadCategory();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
