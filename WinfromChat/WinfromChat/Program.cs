using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinfromChat
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
            //Application.Run(new MainForm());
            LoginForm loginFm = new LoginForm();
            loginFm.StartPosition = FormStartPosition.CenterScreen;



            var result=loginFm.ShowDialog();
            if (result==DialogResult.OK)
            {
                MainForm mainFm = new MainForm();
                Application.Run(mainFm);
            }
            

            
        }
    }
}
