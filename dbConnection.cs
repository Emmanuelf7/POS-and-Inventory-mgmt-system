using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading.Tasks;

namespace POS_and_Inventory_Management_System
{
    
    class dbConnection
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private double dailysales;
        private int productline;
        private string con;
        private int stockonhand;
        private int critical;

       
        public string MyConnection()
        {

           // con = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MyApp_Data\Samuel.mdf; Initial Catalog=Samuel;Integrated Security=True";

            con = @"Data Source=EMMAPC\SQLEXPRESS;Initial Catalog=POSInventoryManagementSystemWindowForm;Integrated Security=True";
            return con;
        }

        public double DailySales()
        {

            string sdate = DateTime.Now.ToString("yyyy/MM/dd");
            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("select isnull(sum(grandTotal),0) as total from tblSales where TransactionDate between'" + sdate + "'and'" + sdate + "'", cn);
            dailysales = double.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return dailysales;
        }

        public double ProductLine()
        {


            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("select count(*) from tblProduct", cn);
            productline = int.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return productline;
        }

        public double StockOnHand()
        {
            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("select isnull(sum(qty),0) as StockInQty from tblProduct", cn);
            stockonhand = int.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return stockonhand;
        }

        public double CriticalItems()
        {
            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("select count(*) from tblProduct", cn);
            critical = int.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return critical;
        }
        public string GetPassword(string user)
        {
            string password = "";
            cn.ConnectionString = MyConnection();
            cn.Open();
            cm = new SqlCommand("select * from tblUser where UserName=@username", cn);
            cm.Parameters.AddWithValue("@username", user);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                password = dr["Password"].ToString();
            }
            dr.Close();
            cn.Close();
            return password;
        }

        public double ExpiringProduct()
        {


            cn = new SqlConnection();
            cn.ConnectionString = con;
            cn.Open();
            cm = new SqlCommand("select count(*) as ExpiringProductCount from tblProduct where ExpiringDate <= DATEADD(day,30, GETDATE())", cn);
            productline = int.Parse(cm.ExecuteScalar().ToString());
            cn.Close();
            return productline;
        }
    }
}
