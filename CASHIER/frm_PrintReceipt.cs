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
    public partial class frm_PrintReceipt : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        dbConnection con = new dbConnection();
       
        string companyName = "Day By Day Cosmetic";
        string address = "Pantang Junction";
        string phone = "Phone #: 050 861 1550";
        frm_mainCashier flist;
        public frm_PrintReceipt(frm_mainCashier f)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            this.flist=f;
        }

        private void frm_PrintReceipt_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        public void LoadReceipt()
        {
             ReportDataSource rptReportDataSource;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Report\rptReceipt.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand("select SalesId, TransactionNo, TransactionDate,bmonth, bmothyear,ProductCode, ProductName, category, price, tax,qty,totalProductPrice,totalPriceqty,subTotal,totaltax,totalprice,discount,grandTotal,payMode, receivedamount, balance from tblSales where TransactionNo like '" + flist.lbl_TransactionNo.Text + "'", cn);
                da.Fill(ds.Tables["dtSalesReport"]);
                cn.Close();

                ReportParameter pTax = new ReportParameter("pTax", flist.lbl_TotalTax.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", flist.lbl_Discount.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", flist.lbl_OverallGrandTotal.Text);
                ReportParameter pAmountReceived = new ReportParameter("pAmountReceived", flist.txt_AmountReceived.Text);
                ReportParameter pChange = new ReportParameter("pChange", flist.lbl_Change.Text);
                ReportParameter pCompanyName = new ReportParameter("pCompanyName", companyName);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pPhoneNo = new ReportParameter("pPhoneNo", phone);
                ReportParameter pTransactionNo = new ReportParameter("pTransactionNo", "Receipt #:" + flist.lbl_TransactionNo.Text);
                ReportParameter pCashier = new ReportParameter("pCashier", flist.lblUser.Text);

                reportViewer1.LocalReport.SetParameters(pTax);
                reportViewer1.LocalReport.SetParameters(pDiscount);
                reportViewer1.LocalReport.SetParameters(pTotal);
                reportViewer1.LocalReport.SetParameters(pAmountReceived);
                reportViewer1.LocalReport.SetParameters(pChange);
                reportViewer1.LocalReport.SetParameters(pCompanyName);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pPhoneNo);
                reportViewer1.LocalReport.SetParameters(pTransactionNo);
                reportViewer1.LocalReport.SetParameters(pCashier);
                rptReportDataSource = new ReportDataSource("DataSet1", ds.Tables["dtSalesReport"]);
                reportViewer1.LocalReport.DataSources.Add(rptReportDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
    }

