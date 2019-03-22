using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WalletTxExtrator
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

            //string[] filePaths = Directory.GetFiles(@"C:\test\XelsWalletFolder\");
            //foreach (string filePath in filePaths)
            //    File.Delete(filePath);

            Application.Run(new XelsWalletInputFile());
        }
    }
}
