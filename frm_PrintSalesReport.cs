using Microsoft.Reporting.WinForms;
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
    public partial class frm_PrintSalesReport : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;
        frm_SalesReport fm;
        public frm_PrintSalesReport(frm_SalesReport flist)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            this.fm = flist;
        }

        private void frm_PrintSalesReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadReport()
        {
            try
            {
                ReportDataSource rptDS;
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Report\rptSoldReport.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                cn.Open();
                if (fm.cboCashier.Text == "All Cashier")
                {
                    da.SelectCommand = new SqlCommand("select SalesId, TransactionNo, TransactionDate,bmonth, bmothyear,ProductCode, ProductName, category, price, tax,totalProductPrice,qty,totalPriceqty,subTotal,totaltax,totalprice,discount,grandTotal,payMode, receivedamount, balance from tblSales where TransactionDate between'" + fm.dt1.Value.ToString("dd-MM-yyyy") + "' and'" + fm.dt2.Value.ToString("dd-MM-yyyy") + "'", cn);
                }
                else
                {
                    da.SelectCommand = new SqlCommand("select SalesId, TransactionNo, TransactionDate,bmonth, bmothyear,ProductCode, ProductName, category, price, tax,totalProductPrice,qty,totalPriceqty,subTotal,totaltax,totalprice,discount,grandTotal,payMode, receivedamount, balance from tblSales where TransactionDate between'" + fm.dt1.Value.ToString("dd-MM-yyyy") + "' and'" + fm.dt2.Value.ToString("dd-MM-yyyy") + "'and Cashier like '" + fm.cboCashier.Text + "'", cn);
                }
                da.Fill(ds.Tables["dtSalesReport"]);
                cn.Close();
                ReportParameter pDate = new ReportParameter("pDate", "Date From:" + fm.dt1.Value.ToString("dd-MM-yyyy") + "To:" + fm.dt2.Value.ToString("dd-MM-yyyy"));
                ReportParameter pCashier = new ReportParameter("pCashier", "Cashier:" + fm.cboCashier.Text);
                ReportParameter pHeader = new ReportParameter("pHeader", "SALES REPORT");
                reportViewer1.LocalReport.SetParameters(pDate);
                reportViewer1.LocalReport.SetParameters(pCashier);
                reportViewer1.LocalReport.SetParameters(pHeader);
                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtSalesReport"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
