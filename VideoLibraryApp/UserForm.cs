using System;
using System.Windows.Forms;
using VideoLibraryApp.Data.Entities;
using VideoLibraryApp.Data.Security;

namespace VideoLibraryApp
{
    /// <summary>
    /// Форма за добавяне или редактиране на потребител.
    /// </summary>
    public partial class UserForm : Form
    {
        private readonly User _user;
        private readonly bool _isEditingSelf;
        public User Result { get; private set; }

        public UserForm() : this(null, false) { }

        public UserForm(User user, bool isEditingSelf = false)
        {
            _user = user;
            _isEditingSelf = isEditingSelf;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_user != null)
            {
                Text = "Редактиране на потребител";
                lblTitle.Text = "Редактиране на потребител";
                txtUsername.Text = _user.Username;
                txtUsername.ReadOnly = true;
                chkIsAdmin.Checked = _user.IsAdmin;
                chkIsAdmin.Enabled = !_isEditingSelf;
                lblPassword.Text = "Нова парола (празно = запази текущата)";
                txtPassword.PlaceholderText = "Оставете празно за запазване";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Въведете потребителско име.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            var password = txtPassword.Text;
            if (_user == null && string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Въведете парола за нов потребител.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(password))
            {
                var passwordError = PasswordValidator.Validate(password);
                if (!string.IsNullOrEmpty(passwordError))
                {
                    MessageBox.Show(passwordError, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return;
                }
            }

            try
            {
                Result = _user != null
                    ? new User { Id = _user.Id, Username = username, PasswordHash = _user.PasswordHash, IsAdmin = chkIsAdmin.Checked }
                    : new User { Username = username, IsAdmin = chkIsAdmin.Checked };

                if (!string.IsNullOrEmpty(password))
                    Result.PasswordHash = PasswordHasher.Hash(password);
                else if (_user != null)
                    Result.PasswordHash = _user.PasswordHash;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
