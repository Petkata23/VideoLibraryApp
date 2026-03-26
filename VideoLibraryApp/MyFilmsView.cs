using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VideoLibraryApp.Data;
using VideoLibraryApp.Data.Entities;
using VideoLibraryApp.Shared.Dtos;

namespace VideoLibraryApp
{
    /// <summary>
    /// UserControl за преглед на запазените филми – показва се в MainForm отдясно на менюто.
    /// </summary>
    public partial class MyFilmsView : UserControl
    {
        private readonly int _userId;

        public MyFilmsView(int userId)
        {
            _userId = userId;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadSavedFilms();
        }

        public void LoadSavedFilms()
        {
            try
            {
                using var ctx = DbContextFactory.Create();
                var savedList = ctx.UserSavedFilms
                    .Where(x => x.UserId == _userId && x.Cassette != null && !x.Cassette.IsDeleted)
                    .Include(x => x.Cassette)
                    .OrderByDescending(x => x.SavedAt)
                    .ToList();
                var saved = MapperProvider.Mapper.Map<List<SavedFilmDto>>(savedList);

                flowPanel.Controls.Clear();
                const int cardWidth = 180;
                const int cardHeight = 320;

                foreach (var item in saved)
                {
                    var card = CassetteCardFactory.CreateSavedFilmCard(
                        item,
                        cardWidth,
                        cardHeight,
                        OpenCassetteDetails,
                        RemoveFromSaved);
                    flowPanel.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане:\n" + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenCassetteDetails(SavedFilmDto item)
        {
            if (item?.Cassette == null) return;
            var cassette = GetCassetteById(item.Cassette.Id);
            if (cassette == null) return;
            using var form = new CassetteDetailForm(cassette);
            form.ShowDialog(FindForm());
        }

        private static Cassette GetCassetteById(int id)
        {
            using var ctx = DbContextFactory.Create();
            return ctx.Cassettes.IgnoreQueryFilters().FirstOrDefault(c => c.Id == id && !c.IsDeleted);
        }

        private void RemoveFromSaved(int cassetteId)
        {
            try
            {
                using var ctx = DbContextFactory.Create();
                var saved = ctx.UserSavedFilms.FirstOrDefault(x => x.UserId == _userId && x.CassetteId == cassetteId);
                if (saved != null)
                {
                    ctx.UserSavedFilms.Remove(saved);
                    ctx.SaveChanges();
                    MessageBox.Show("Филмът е премахнат от запазените.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSavedFilms();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e) => LoadSavedFilms();
    }
}
