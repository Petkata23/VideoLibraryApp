using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VideoLibraryApp.Data;
using VideoLibraryApp.Data.Entities;
using VideoLibraryApp.Data.Security;

namespace VideoLibraryApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode && lblLogo != null)
                lblLogo.Text = "\uD83C\uDFAC";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Въведете потребителско име.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Въведете парола.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using var context = DbContextFactory.Create();
                var user = context.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

                if (user == null || !PasswordHasher.Verify(password, user.PasswordHash))
                {
                    MessageBox.Show("Невалидно потребителско име или парола.", "Грешка при вход", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                Hide();
                using (var mainForm = new MainForm(user.IsAdmin, user.Username, user.Id))
                {
                    mainForm.ShowDialog();
                }
                Show();
                txtPassword.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при свързване с базата данни:\n{ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnLogin_Click(sender, e);
            }
        }

        private void LnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            using (var registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
            Show();
        }
    }
}
