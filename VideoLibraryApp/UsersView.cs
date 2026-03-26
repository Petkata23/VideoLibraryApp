using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VideoLibraryApp.Data;
using VideoLibraryApp.Data.Entities;
using VideoLibraryApp.Shared.Dtos;

namespace VideoLibraryApp
{
    /// <summary>
    /// UserControl за управление на потребители – CRUD операции (само за администратори).
    /// </summary>
    public partial class UsersView : UserControl
    {
        private readonly int _currentUserId;

        public UsersView(int currentUserId = 0)
        {
            _currentUserId = currentUserId;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadUsers();
        }

        public void LoadUsers()
        {
            try
            {
                using var ctx = DbContextFactory.Create();
                var usersList = ctx.Users.OrderBy(u => u.Username).ToList();
                var users = MapperProvider.Mapper.Map<List<UserDto>>(usersList);

                dgvUsers.Rows.Clear();
                foreach (var u in users)
                {
                    dgvUsers.Rows.Add(u.Id, u.Username, u.IsAdmin ? "Да" : "Не");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане:\n" + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using var form = new UserForm();
            if (form.ShowDialog(FindForm()) != DialogResult.OK || form.Result == null) return;
            try
            {
                using var ctx = DbContextFactory.Create();
                var usernameLower = form.Result.Username?.Trim().ToLower() ?? "";
                if (ctx.Users.IgnoreQueryFilters().Any(x => x.Username.ToLower() == usernameLower))
                {
                    MessageBox.Show("Потребител с това име вече съществува.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ctx.Users.Add(form.Result);
                ctx.SaveChanges();
                MessageBox.Show("Потребителят е добавен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null) return;
            var id = (int)row.Cells["colId"].Value;
            var username = row.Cells["colUsername"].Value?.ToString() ?? "";

            User user;
            using (var ctx = DbContextFactory.Create())
            {
                user = ctx.Users.IgnoreQueryFilters().FirstOrDefault(u => u.Id == id && !u.IsDeleted);
            }
            if (user == null)
            {
                MessageBox.Show("Потребителят не е намерен.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var form = new UserForm(user, isEditingSelf: user.Id == _currentUserId);
            if (form.ShowDialog(FindForm()) != DialogResult.OK || form.Result == null) return;
            try
            {
                using var ctx = DbContextFactory.Create();
                var toUpdate = ctx.Users.Find(user.Id);
                if (toUpdate == null) return;
                toUpdate.PasswordHash = form.Result.PasswordHash;
                if (user.Id != _currentUserId)
                    toUpdate.IsAdmin = form.Result.IsAdmin;
                ctx.SaveChanges();
                MessageBox.Show("Потребителят е обновен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var row = GetSelectedRow();
            if (row == null) return;
            var id = (int)row.Cells["colId"].Value;
            var username = row.Cells["colUsername"].Value?.ToString() ?? "";

            if (id == _currentUserId)
            {
                MessageBox.Show("Не можете да изтриете собствения си акаунт.", "Забранено", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(FindForm(), "Сигурни ли сте, че искате да изтриете потребителя \"" + username + "\"?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using var ctx = DbContextFactory.Create();
                var toDelete = ctx.Users.IgnoreQueryFilters().FirstOrDefault(u => u.Id == id && !u.IsDeleted);
                if (toDelete == null) return;
                toDelete.IsDeleted = true;
                ctx.SaveChanges();
                MessageBox.Show("Потребителят е изтрит.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e) => LoadUsers();

        private DataGridViewRow GetSelectedRow()
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Изберете потребител.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return dgvUsers.SelectedRows[0];
        }
    }
}
