﻿using System;
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
    public partial class frm_Dashboard : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        public frm_Dashboard()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
        }

        private void frm_Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void Dashboard_Load_Resise(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
        }
    }
}
