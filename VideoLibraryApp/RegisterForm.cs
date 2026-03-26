using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VideoLibraryApp.Data;
using VideoLibraryApp.Data.Entities;
using VideoLibraryApp.Data.Security;

namespace VideoLibraryApp
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode && lblLogo != null)
                lblLogo.Text = "\uD83C\uDFAC";
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Въведете потребителско име.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (username.Length < 3)
            {
                MessageBox.Show("Потребителското име трябва да е поне 3 символа.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            var passwordError = PasswordValidator.Validate(password);
            if (!string.IsNullOrEmpty(passwordError))
            {
                MessageBox.Show(passwordError, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Паролите не съвпадат.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            try
            {
                using var context = DbContextFactory.Create();

                var exists = context.Users.IgnoreQueryFilters().Any(u => u.Username.ToLower() == username.ToLower());
                if (exists)
                {
                    MessageBox.Show("Това потребителско име вече е заето.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                    return;
                }

                var user = new User
                {
                    Username = username.Trim(),
                    PasswordHash = PasswordHasher.Hash(password),
                    IsAdmin = false
                };

                context.Users.Add(user);
                context.SaveChanges();

                MessageBox.Show("Регистрацията е успешна! Влезте с вашите данни.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Грешка при регистрация:\n{ex.Message}", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtConfirmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BtnRegister_Click(sender, e);
            }
        }

        private void LnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }
    }
}
