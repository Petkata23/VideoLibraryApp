namespace VideoLibraryApp
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lnkRegister = new LinkLabel();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            lblPassword = new Label();
            lblUsername = new Label();
            lblTitle = new Label();
            lblLogo = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(22, 30, 48);
            pnlMain.Controls.Add(lnkRegister);
            pnlMain.Controls.Add(btnLogin);
            pnlMain.Controls.Add(txtPassword);
            pnlMain.Controls.Add(txtUsername);
            pnlMain.Controls.Add(lblPassword);
            pnlMain.Controls.Add(lblUsername);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(lblLogo);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(40);
            pnlMain.Size = new Size(440, 400);
            pnlMain.TabIndex = 0;
            // 
            // lnkRegister
            // 
            lnkRegister.AutoSize = true;
            lnkRegister.ForeColor = Color.FromArgb(255, 200, 100);
            lnkRegister.LinkColor = Color.FromArgb(255, 200, 100);
            lnkRegister.Location = new Point(43, 320);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(211, 15);
            lnkRegister.TabIndex = 7;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Нямате акаунт? Регистрирайте се тук";
            lnkRegister.LinkClicked += LnkRegister_LinkClicked;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(255, 200, 100);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogin.ForeColor = Color.FromArgb(15, 22, 36);
            btnLogin.Location = new Point(43, 265);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(354, 45);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Вход";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.Location = new Point(43, 215);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(354, 27);
            txtPassword.TabIndex = 5;
            txtPassword.KeyDown += TxtPassword_KeyDown;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsername.Location = new Point(43, 155);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(354, 27);
            txtUsername.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblPassword.ForeColor = Color.FromArgb(220, 220, 235);
            lblPassword.Location = new Point(43, 193);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(56, 19);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Парола";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsername.ForeColor = Color.FromArgb(220, 220, 235);
            lblUsername.Location = new Point(43, 133);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(134, 19);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Потребителско име";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(255, 200, 100);
            lblTitle.Location = new Point(115, 75);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(246, 37);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Вход в системата";
            // 
            // lblLogo
            // 
            lblLogo.Font = new Font("Segoe UI Emoji", 32F, FontStyle.Regular, GraphicsUnit.Point);
            lblLogo.ForeColor = Color.FromArgb(255, 200, 100);
            lblLogo.Location = new Point(43, 25);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(65, 65);
            lblLogo.TabIndex = 0;
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 26, 42);
            ClientSize = new Size(440, 400);
            Controls.Add(pnlMain);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Видеотека - Вход";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkRegister;
    }
}
