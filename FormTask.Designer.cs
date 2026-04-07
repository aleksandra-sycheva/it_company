namespace it_company
{
    partial class FormTasks
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
            panelTop = new Panel();
            pictureBoxLogo = new PictureBox();
            lbUser = new Label();
            btnLogout = new Button();
            dgvTasks = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(pictureBoxLogo);
            panelTop.Controls.Add(lbUser);
            panelTop.Controls.Add(btnLogout);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1200, 80);
            panelTop.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.Логотип3;
            pictureBoxLogo.Location = new Point(12, 12);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(60, 60);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // lbUser
            // 
            lbUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbUser.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            lbUser.ForeColor = Color.Black;
            lbUser.Location = new Point(850, 25);
            lbUser.Name = "lbUser";
            lbUser.Size = new Size(250, 30);
            lbUser.TabIndex = 1;
            lbUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(156, 211, 216);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            btnLogout.Location = new Point(1100, 20);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(88, 40);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Выйти";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // dgvTasks
            // 
            dgvTasks.BackgroundColor = Color.White;
            dgvTasks.BorderStyle = BorderStyle.None;
            dgvTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTasks.Dock = DockStyle.Fill;
            dgvTasks.Location = new Point(0, 80);
            dgvTasks.Name = "dgvTasks";
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.RowHeadersWidth = 51;
            dgvTasks.RowTemplate.Height = 40;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.Size = new Size(1200, 520);
            dgvTasks.TabIndex = 1;
            // 
            // FormTasks
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1200, 600);
            Controls.Add(dgvTasks);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F);
            Name = "FormTasks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список задач - ТехноСофт";
            panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTasks).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView dgvTasks;
    }
}