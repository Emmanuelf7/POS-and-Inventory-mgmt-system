using POS_and_Inventory_Management_System.ADMIN;
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
namespace POS_and_Inventory_Management_System.CASHIER
{
    public partial class frm_mainCashier : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbcon = new dbConnection();
        SqlDataReader dr;
        string stitle = "POS";
        public frm_mainCashier()
        {
           
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            NotifyExpiringProduct();
           
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

        private void frm_mainCashier_Load(object sender, EventArgs e)
        {
            txt_Search_Product_Barcode.Focus();
            LoadDiscount();        
            calculate_populate_Labels();
            ADDToLIST();
            btn_Pay.Enabled = false;
                    
            GetTransactionNo();
        }


        private void GetTransactionNo()
        {
            
            try
            {
                string sdate = DateTime.Now.ToString("yyMMddhmm");
                string transno;
                int count;
                cn.Open();
               Random random = new Random();
                cm = new SqlCommand("SELECT * FROM tblSales where TransactionNo like '" + sdate + "%'order by SalesId desc", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    transno = dr[0].ToString();
                    count = random.Next(1, 9);
                    lbl_TransactionNo.Text = sdate + (count + 1);

                }
                else
                {
                    transno = sdate + "1";
                    lbl_TransactionNo.Text = transno;
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void ADDToLIST()
{
    using (SqlConnection cn = new SqlConnection(dbcon.MyConnection()))
    {
        SqlTransaction transaction = null;
        SqlCommand cm = null;
        SqlDataReader dr = null;

        try
        {
            cn.Open();
            transaction = cn.BeginTransaction();

            //cm = new SqlCommand("select ProductId, PCode, ProductDate, ProductName, Category, CostPrice, Profit, SalesPrice, Tax, TotalPrice, StockInQty, Barcode from tblProduct as p inner join tblDiscount as d on p.productId=d.DiscountId where Barcode like @searchBarcode", cn, transaction);
            cm = new SqlCommand("select ProductId, PCode, ProductDate, ProductName, Category, CostPrice, Profit, SalesPrice, Tax, TotalPrice, StockInQty, Barcode from tblProduct  where Barcode like @searchBarcode", cn, transaction);
            cm.Parameters.AddWithValue("@searchBarcode", "%" + txt_Search_Product_Barcode.Text + "%");

            dr = cm.ExecuteReader();

            List<Product> products = new List<Product>();

            while (dr.Read())
            {
                if (txt_Search_Product_Barcode.Text == String.Empty)
                {
                    return;

                }
                
                var product = new Product
                {
                    ProductId = dr["ProductId"].ToString(),
                    PCode = dr["PCode"].ToString(),
                    ProductName = dr["ProductName"].ToString(),
                    Category = dr["Category"].ToString(),
                    SalePrice = Convert.ToDecimal(dr["SalesPrice"].ToString()),
                    Tax = Convert.ToDecimal(dr["Tax"].ToString()),
                  //  Discount = Convert.ToDecimal(dr["0"].ToString()),
                   TotalPrice = Convert.ToDecimal(dr["TotalPrice"].ToString()),
                    StockInQty = Convert.ToInt32(dr["StockInQty"])
                   
                   
                };
               
                products.Add(product);
                
            }

            dr.Close();
           
            foreach (var product in products)
            {
                bool itemFound = false;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == product.ProductId)
                    {
                        int quantity = Convert.ToInt32(row.Cells[6].Value) + 1;

                        if (quantity > product.StockInQty)
                        {
                            MessageBox.Show("Insufficient stock available for {product.ProductName}.", "Stock Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        decimal discout=0;
                        row.Cells[6].Value = quantity;
                        row.Cells[8].Value = discout;
                        decimal subtotal = product.SalePrice + product.SalePrice * product.Tax / 100;
                        decimal Totalprice = subtotal * quantity;
                        row.Cells[7].Value = Totalprice.ToString("#,##0.00");
                        row.Cells[8].Value = discout.ToString("#,##0.00");                       
                        decimal updatedTotalPrice = subtotal * quantity/discout;
                        row.Cells[9].Value = updatedTotalPrice.ToString("#,##0.00");                       
                        itemFound = true;

                        break;
                    }
                }

                if (!itemFound)
                {
                    if (product.StockInQty <= 0)
                    {
                        MessageBox.Show("The product {product.ProductName} is out of stock.", "Stock Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    decimal TotalPrice = product.SalePrice * (product.Tax / 100) + product.SalePrice;
                    decimal totalqtyprice = product.SalePrice * (product.Tax / 100) + product.SalePrice;
                    dataGridView1.Rows.Add(product.ProductId, product.PCode, product.ProductName, product.Category, product.SalePrice, product.Tax, 1, product.TotalPrice.ToString("#,##0.00"), product.Discount.ToString("#,##0.00"), totalqtyprice.ToString("#,##0.00"));
                }

                using (SqlCommand updateCmd = new SqlCommand("UPDATE tblProduct SET StockInQty = StockInQty - 1 WHERE ProductId = @ProductId", cn, transaction))
                {
                    updateCmd.Parameters.AddWithValue("@ProductId", product.ProductId);
                    updateCmd.ExecuteNonQuery();
                }
            }

            txt_Search_Product_Barcode.Clear();
            txt_Search_Product_Barcode.Focus();
            calculate_populate_Labels();

            transaction.Commit();
        }
        catch (FormatException ex)
        {
            transaction.Rollback();
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            dr.Dispose();
            cm.Dispose();
            cn.Close();
        }
    }
}

private class Product
{
    public string ProductId { get; set; }
    public string PCode { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal SalePrice { get; set; }
    public decimal Tax { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
    public int StockInQty { get; set; }
}

        
        //check stock qty; -
        private int CheckStockAvailability(string productCode)
        {
            int stockQty = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(dbcon.MyConnection()))
                {
                    cn.Open();
                    using (SqlCommand cm = new SqlCommand("SELECT StockInQty FROM tblProduct WHERE PCode = @ProductCode", cn))
                    {
                        cm.Parameters.AddWithValue("@ProductCode", productCode);
                        stockQty = Convert.ToInt32(cm.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stockQty;
        }

        private string CalculateTotalQuantity()
        {
            int totalQuantity = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[6].Value != null)
                {
                    int quantity = Convert.ToInt32(row.Cells[6].Value);
                    totalQuantity += quantity;
                }
                
            }

            return totalQuantity.ToString();
        }
        private string CalculateTotalTax()
        {
            decimal totalQuantity = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[5].Value != null)
                {

                    decimal tax = (Convert.ToDecimal(row.Cells[4].Value)*Convert.ToDecimal(row.Cells[5].Value)/100)*Convert.ToDecimal(row.Cells[6].Value);
                   // decimal totaltax = Convert.ToDecimal(row.Cells[6].Value) + tax;
                  
                    totalQuantity += tax;
                }

            }

            return totalQuantity.ToString("#,##0.00");
        }
        private string CalculateTotalPrice()
        {
            decimal totalQuantity = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[9].Value != null)
                {
                    decimal quantity = Convert.ToDecimal(row.Cells[4].Value) * Convert.ToDecimal(row.Cells[6].Value);
                    totalQuantity += quantity;
                    
                }

            }

            return totalQuantity.ToString("#,##0.00");
        }

        private string CalculateSubtotal()
        {
            decimal totalQuantity = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[7].Value != null)
                {
                    decimal quantity = Convert.ToDecimal(row.Cells[9].Value);
                    totalQuantity += quantity;
                    //decimal quantity = Convert.ToDecimal(row.Cells[4].Value) * Convert.ToDecimal(row.Cells[6].Value);
                    //totalQuantity += quantity;
                    // quantity = Convert.ToDecimal(row.Cells[8].Value);
                }

            }

            return totalQuantity.ToString("#,##0.00");
        }


        //====================================================================================================
        private void txt_Search_Product_Barcode_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_Search_Product_Barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    using (SqlConnection cn = new SqlConnection(dbcon.MyConnection()))
                    {
                        cn.Open();
                        using (SqlCommand cm = new SqlCommand("select * from tblProduct where Barcode like @barcode", cn))
                        {
                            cm.Parameters.AddWithValue("@barcode", txt_Search_Product_Barcode.Text);

                            using (SqlDataReader dr = cm.ExecuteReader())
                            {
                                if (dr.Read())
                                {
                                    // Validate product quantity to avoid selling when the product is out of stock
                                    int qty = int.Parse(dr["StockInQty"].ToString());
                                    string _pcode = dr["PCode"].ToString();
                                    string _productname = dr["ProductName"].ToString();
                                    decimal _price = decimal.Parse(dr["SalesPrice"].ToString());

                                    // Close the reader before processing
                                   
                                   
                                }
                                dr.Close();
                                ADDToLIST();
                            }

                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            
        }
    
   //CALCULATE AND POPULATE THE LABELS

        public void calculate_populate_Labels()
        {
            lbl_NoOfItems.Text = CalculateTotalQuantity();
            lbl_TotalPrice.Text = CalculateSubtotal();
            lbl_TotalTax.Text = CalculateTotalTax();
            lbl_subTotal.Text = CalculateTotalPrice();
            decimal grandTotal = Convert.ToDecimal(lbl_TotalPrice.Text) - Convert.ToDecimal(lbl_Discount.Text);
            lbl_GrandTotal.Text = grandTotal.ToString("#,##0.00");
            lbl_OverallGrandTotal.Text = grandTotal.ToString("#,##0.00");
        }

        private void txt_AmountReceived_TextChanged(object sender, EventArgs e)
        {

            btn_Pay.Enabled = false;
            lbl_Change.Text = "";
            string enteredText = txt_AmountReceived.Text;
            if (enteredText != "")
            {
                decimal totalAmount = Convert.ToDecimal(lbl_GrandTotal.Text);
                decimal amountGiven = Convert.ToDecimal(enteredText);
                decimal change = amountGiven - totalAmount;
                lbl_Change.Text = change.ToString();
                btn_Pay.Enabled = true;
            }
            else
            {
                decimal totalAmount = Convert.ToDecimal(lbl_GrandTotal.Text);
                decimal amountGiven = 0;
                decimal change = amountGiven - totalAmount;
                lbl_Change.Text = change.ToString();
                btn_Pay.Enabled = true;
            }
           
        }

        private void txt_Discount_TextChanged(object sender, EventArgs e)
        {
            decimal discountPercentage = Convert.ToDecimal(txt_Discount.Text) / 100 * Convert.ToDecimal(lbl_TotalPrice.Text);
            lbl_Discount.Text = discountPercentage.ToString("#,##0.00");
            decimal grandTotal = Convert.ToDecimal(lbl_TotalPrice.Text) - Convert.ToDecimal(lbl_Discount.Text);
            lbl_GrandTotal.Text = grandTotal.ToString("#,##0.00");
            lbl_OverallGrandTotal.Text = grandTotal.ToString("#,##0.00");
        }
        // WHAT IS THE LINE OF THIS CODE.... ITS RUBBISH.
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        public void LoadDiscount()
        {
            try
            {
                
                cn.Open();
                cm = new SqlCommand("select * from tblDiscount", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {

                    txt_Discount.Text = dr["Discount"].ToString();
                }
                dr.Close();
                cn.Close();
            }
                 
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Set_Discount_Click(object sender, EventArgs e)
        {
            frm_Discount frm = new frm_Discount(this);
            frm.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lbl_Date.Text = DateTime.Now.ToString("dd-MMMM-yyyy");
            if (txt_AmountReceived.Text != "")
            {
                btn_Pay.Enabled = true;
            }
            else
            {
                btn_Pay.Enabled = false;
            }
        }


        private void Save_Sales()
        {
            if (cbo_PaymentMode.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please Select Payment Mode?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                cbo_PaymentMode.Focus();
                return;
            }
            if (txt_AmountReceived.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Please Enter Amount Received?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txt_AmountReceived.Focus();
                return;
            }

           
                SqlTransaction transaction = null;

                try
                {
                    if ((double.Parse(lbl_GrandTotal.Text) < 0) || (txt_AmountReceived.Text == String.Empty))
                    {
                        MessageBox.Show("Insufficient amount. Please enter the correct amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        using (SqlConnection cn = new SqlConnection(dbcon.MyConnection()))
                        {
                            cn.Open();
                            transaction = cn.BeginTransaction();

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[0].Value != null) // Ensure the row is not empty
                                {

                                    // Insert into sales table
                                    using (SqlCommand cm = new SqlCommand("INSERT INTO tblSales (TransactionNo, TransactionDate, bmonth, bmothyear, ProductCode, ProductName, category, price, tax,qty, totalProductPrice,  totalPriceqty, subTotal, totaltax, totalprice, discount, grandTotal, payMode, receivedamount, balance, cashier) VALUES (@TransactionNo, @TransactionDate, @bmonth, @bmothyear, @ProductCode, @ProductName, @category, @price, @tax,@qty, @totalProductPrice, @totalPriceqty, @subTotal, @totaltax, @totalprice, @discount, @grandTotal, @payMode, @receivedamount, @balance, @cashier)", cn, transaction))
                                    {
                                        cm.Parameters.AddWithValue("@TransactionNo", lbl_TransactionNo.Text);
                                        cm.Parameters.AddWithValue("@TransactionDate", dtTransactionDate.Value.Date);
                                        cm.Parameters.AddWithValue("@bmonth", DateTime.Now.ToString("MM"));
                                        cm.Parameters.AddWithValue("@bmothyear", DateTime.Now.ToString("MMMM-yyyy"));
                                        cm.Parameters.AddWithValue("@ProductCode", dataGridView1.Rows[i].Cells[1].Value.ToString());
                                        cm.Parameters.AddWithValue("@ProductName", dataGridView1.Rows[i].Cells[2].Value.ToString());
                                        cm.Parameters.AddWithValue("@category", dataGridView1.Rows[i].Cells[3].Value.ToString());
                                        cm.Parameters.AddWithValue("@price", dataGridView1.Rows[i].Cells[4].Value.ToString());
                                        cm.Parameters.AddWithValue("@tax", dataGridView1.Rows[i].Cells[5].Value.ToString());                                       
                                        cm.Parameters.AddWithValue("@totalProductPrice", dataGridView1.Rows[i].Cells[7].Value.ToString());
                                        cm.Parameters.AddWithValue("@qty", dataGridView1.Rows[i].Cells[6].Value.ToString());
                                        cm.Parameters.AddWithValue("@discount", dataGridView1.Rows[i].Cells[8].Value.ToString());
                                        cm.Parameters.AddWithValue("@totalPriceqty",Convert.ToDecimal(dataGridView1.Rows[i].Cells[9].Value.ToString()));                                   
                                        cm.Parameters.AddWithValue("@subTotal", lbl_subTotal.Text);
                                        cm.Parameters.AddWithValue("@totaltax", lbl_TotalTax.Text);
                                        cm.Parameters.AddWithValue("@totalprice", lbl_TotalPrice.Text);
                                       // cm.Parameters.AddWithValue("@discount", lbl_Discount.Text);
                                        cm.Parameters.AddWithValue("@grandTotal", lbl_GrandTotal.Text);
                                        cm.Parameters.AddWithValue("@receivedamount", txt_AmountReceived.Text);
                                        cm.Parameters.AddWithValue("@balance", lbl_Change.Text);
                                        cm.Parameters.AddWithValue("@payMode", cbo_PaymentMode.Text);
                                        cm.Parameters.AddWithValue("@cashier", lblUser.Text);
                                        cm.ExecuteNonQuery();                                                                                                                     
                                        ReduceStock(dataGridView1.Rows[i].Cells[1].Value.ToString(), int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()));
                                    }
                                }
                            }


                            // Commit transaction
                            transaction.Commit();
                            MessageBox.Show("New Transaction successfully saved!", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  
                       // MessageBox.Show("Insufficient amount. Please enter the correct amount!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
                }
            }
    
        private void ReduceStock(string productCode, int quantity)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("UPDATE tblProduct SET StockInQty = StockInQty - @Quantity WHERE PCode = @ProductCode", cn);
                cm.Parameters.AddWithValue("@Quantity", quantity);
                cm.Parameters.AddWithValue("@ProductCode", productCode);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void Clear()
        {
            txt_Search_Product_Barcode.Clear();
            dataGridView1.Rows.Clear();
            lbl_Change.Text = "0.00";
            txt_Discount.Text = "0.00";
            lbl_Discount.Text = "0.00";
            lbl_GrandTotal.Text = "0.00";
            lbl_NoOfItems.Text = "0";
            lbl_GrandTotal.Text = "0.00";
            lbl_TotalPrice.Text = "0.00";
            lbl_TotalTax.Text = "0.00";
            lbl_subTotal.Text = "0.00";
            lbl_OverallGrandTotal.Text = "0.00";
            cbo_PaymentMode.SelectedIndex = -1;
            txt_AmountReceived.Clear();

        }
        private void btn_Pay_Click(object sender, EventArgs e)
        {
            
            frm_PrintReceipt frm = new frm_PrintReceipt(this); 
             Save_Sales();            
            frm.LoadReceipt();           
            frm.Show();
            GetTransactionNo();
            txt_Search_Product_Barcode.Focus();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            Clear();
        }


        //===================== list item remove to be work on otoday evenin. ok=====================
        private void btn_Remove_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_Change_Password_Click(object sender, EventArgs e)
        {
            frm_ChangePassword frm = new frm_ChangePassword(this);
            frm.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Unable to logout. Please cancel all the transactions.","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("LOGOUT THE APPLICATION ?", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frm_login frm = new frm_login();
                frm.ShowDialog();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            frm_SalesReport frm = new frm_SalesReport();
            frm.dt1.Enabled = false;
            frm.dt2.Enabled = false;
            frm.cboCashier.Enabled = false;
            frm.cboCashier.Text = lblUser.Text;
            frm.Show();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            frm_SearchProduct frm = new frm_SearchProduct(this);
            
            frm.Show();
        }

        private void cbo_PaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            btn_Pay.Enabled = false; 
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        }
        }
    

