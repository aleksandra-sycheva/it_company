using System;
using System.Windows.Forms;

namespace it_company
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new FormLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    if (loginForm.IsGuest)
                    {
                        Application.Run(new FormTasks(null, true));
                    }
                    else
                    {
                        Application.Run(new FormTasks(loginForm.CurrentUser, false));
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}