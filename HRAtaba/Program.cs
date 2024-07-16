using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HRAtaba
{
    internal static class Program
    {


        public static int userid = 1;

        public static int BranchId = 1;
    
        public static string NameUser = "Admin";
        public static string NameBranch = "الفرع الرئيسي";
        public static string lang = "ar";


        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EmployeesSearch());
        }
    }
}
