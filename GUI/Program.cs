using System;
using System.Windows.Forms;
using System.IO;

namespace GUI
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

            if (File.Exists(@"C:\Generating Attendance Reports - Files\\companyName.txt"))
                Application.Run(new MenuFrm());
            else
                Application.Run(new ListCreationFrm());
        }
    }
}
