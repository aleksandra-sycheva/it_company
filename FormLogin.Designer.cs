namespace it_company
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            picLogo = new PictureBox();
            lblTitle = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnGuest = new Button();
            panelMain = new Panel();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.Transparent;
            picLogo.Image = Properties.Resources.Логотип3;
            picLogo.Location = new Point(175, 30);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(150, 150);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Times New Roman", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(100, 190);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 50);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "ТехноСофт";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.Font = new Font("Times New Roman", 12F);
            lblEmail.ForeColor = Color.Black;
            lblEmail.Location = new Point(75, 260);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(80, 25);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "Email:";
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Times New Roman", 12F);
            lblPassword.ForeColor = Color.Black;
            lblPassword.Location = new Point(75, 320);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(80, 25);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Пароль:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Times New Roman", 12F);
            txtEmail.Location = new Point(160, 257);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "example@technosoft.ru";
            txtEmail.Size = new Size(280, 30);
            txtEmail.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Times New Roman", 12F);
            txtPassword.Location = new Point(160, 317);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 30);
            txtPassword.TabIndex = 5;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(156, 211, 216);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(158, 371);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(188, 40);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.FromArgb(242, 242, 242);
            btnGuest.FlatStyle = FlatStyle.Flat;
            btnGuest.Font = new Font("Times New Roman", 10F);
            btnGuest.ForeColor = Color.Black;
            btnGuest.Location = new Point(155, 426);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(191, 40);
            btnGuest.TabIndex = 7;
            btnGuest.Text = "Войти как гость";
            btnGuest.UseVisualStyleBackColor = false;
            btnGuest.Click += BtnGuest_Click;
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(picLogo);
            panelMain.Controls.Add(lblTitle);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(lblPassword);
            panelMain.Controls.Add(txtEmail);
            panelMain.Controls.Add(txtPassword);
            panelMain.Controls.Add(btnLogin);
            panelMain.Controls.Add(btnGuest);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(500, 480);
            panelMain.TabIndex = 0;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            ClientSize = new Size(500, 480);
            Controls.Add(panelMain);
            Font = new Font("Times New Roman", 12F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Авторизация - ТехноСофт";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }


        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Panel panelMain;
    }
}