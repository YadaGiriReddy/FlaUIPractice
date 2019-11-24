using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace BankSystem
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //Application.Run(new Welcome());
                Application.Run(new Main());
            }
            catch
            {
                Application.Exit();
            }
        }
    }
}
