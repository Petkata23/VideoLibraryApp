using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VideoLibraryApp.Data;
using VideoLibraryApp.Data.Entities;
using VideoLibraryApp.Shared.Dtos;

namespace VideoLibraryApp
{
    /// <summary>
    /// UserControl за преглед на касети – показва се в MainForm отдясно на менюто.
    /// </summary>
    public partial class CassettesView : UserControl
    {
        private readonly bool _isAdmin;
        private readonly int _userId;
        private List<CassetteDto> _cassettes = new List<CassetteDto>();
        private readonly Action _onRefreshParent;

        public CassettesView(bool isAdmin, int userId, Action onRefreshParent = null)
        {
            _isAdmin = isAdmin;
            _userId = userId;
            _onRefreshParent = onRefreshParent;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            btnAdd.Visible = _isAdmin;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
            if (!_isAdmin)
                lblTitle.Text = "Касети";
            LoadCassettes();
        }

        public void LoadCassettes()
        {
            try
            {
                using var ctx = DbContextFactory.Create();
                var cassettes = ctx.Cassettes.OrderBy(c => c.Title).ToList();
                _cassettes = MapperProvider.Mapper.Map<List<CassetteDto>>(cassettes);

                flowPanel.Controls.Clear();
                var cardWidth = _isAdmin ? 200 : 180;
                var cardHeight = _isAdmin ? 370 : 340;

                foreach (var c in _cassettes)
                {
                    var card = CassetteCardFactory.CreateCard(c, cardWidth, cardHeight, _isAdmin,
                        id => CardViewDetails(id),
                        id => SaveFilm(id),
                        _isAdmin ? (Action<int>)EditCard : null,
                        _isAdmin ? (Action<int>)DeleteCard : null);
                    flowPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане:\n" + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CardViewDetails(int id)
        {
            var cassette = GetCassetteById(id);
            if (cassette == null) return;
            using var form = new CassetteDetailForm(cassette);
            form.ShowDialog(FindForm());
        }

        private void SaveFilm(int id)
        {
            if (_userId <= 0) return;
            try
            {
                using var ctx = DbContextFactory.Create();
                if (ctx.UserSavedFilms.Any(x => x.UserId == _userId && x.CassetteId == id))
                {
                    MessageBox.Show("Този филм вече е записан.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ctx.UserSavedFilms.Add(new UserSavedFilm { UserId = _userId, CassetteId = id });
                ctx.SaveChanges();
                MessageBox.Show("Филмът е записан в Моите филми.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditCard(int id)
        {
            var cassette = GetCassetteById(id);
            if (cassette == null) return;
            using var form = new CassetteForm(cassette);
            if (form.ShowDialog(FindForm()) != DialogResult.OK || form.Result == null) return;
            try
            {
                using var ctx = DbContextFactory.Create();
                var toUpdate = ctx.Cassettes.Find(cassette.Id);
                if (toUpdate == null) return;
                toUpdate.Title = form.Result.Title;
                toUpdate.Director = form.Result.Director;
                toUpdate.Year = form.Result.Year;
                toUpdate.Genre = form.Result.Genre;
                toUpdate.Description = form.Result.Description;
                toUpdate.ImageData = form.Result.ImageData;
                ctx.SaveChanges();
                MessageBox.Show("Касетата е обновена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCassettes();
                _onRefreshParent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCard(int id)
        {
            var cassette = GetCassetteById(id);
            if (cassette == null) return;
            if (MessageBox.Show(FindForm(), "Сигурни ли сте, че искате да изтриете \"" + cassette.Title + "\"?", "Потвърждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            try
            {
                using var ctx = DbContextFactory.Create();
                var toDelete = ctx.Cassettes.IgnoreQueryFilters().FirstOrDefault(c => c.Id == id);
                if (toDelete == null) return;
                toDelete.IsDeleted = true;
                ctx.SaveChanges();
                MessageBox.Show("Касетата е изтрита.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCassettes();
                _onRefreshParent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Cassette GetCassetteById(int id)
        {
            using var ctx = DbContextFactory.Create();
            return ctx.Cassettes.IgnoreQueryFilters().FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using var form = new CassetteForm();
            if (form.ShowDialog(FindForm()) != DialogResult.OK || form.Result == null) return;
            try
            {
                using var ctx = DbContextFactory.Create();
                ctx.Cassettes.Add(form.Result);
                ctx.SaveChanges();
                MessageBox.Show("Касетата е добавена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCassettes();
                _onRefreshParent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e) { }
        private void BtnDelete_Click(object sender, EventArgs e) { }

        private void BtnRefresh_Click(object sender, EventArgs e) => LoadCassettes();
    }
}
