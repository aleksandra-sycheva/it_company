using System;
using System.Linq;
using System.Windows.Forms;
using it_company.models;

namespace it_company
{
    public partial class FormLogin : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите email и пароль", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new ItCompanyContext())
                {
                    var user = db.Users
                        .Where(u => u.Email == email && u.PasswordHash == password)
                        .FirstOrDefault();

                    if (user != null)
                    {
                        CurrentUser = user;
                        IsGuest = false;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неверный email или пароль", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к БД: {ex.Message}", "Критическая ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            IsGuest = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}