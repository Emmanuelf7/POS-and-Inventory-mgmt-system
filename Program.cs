using POS_and_Inventory_Management_System.ADMIN;
using POS_and_Inventory_Management_System.CASHIER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_and_Inventory_Management_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new frm_mainCashier());
            //Application.Run(new frm_login());

         // Application.Run(new frm_mainAdmin());
            
        }
    }
}
