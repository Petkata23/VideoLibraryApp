using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VideoLibraryApp.Data.Entities;

namespace VideoLibraryApp
{
    /// <summary>
    /// Форма за добавяне или редактиране на касета.
    /// </summary>
    public partial class CassetteForm : Form
    {
        private readonly Cassette _cassette;
        public Cassette Result { get; private set; }

        public CassetteForm() : this(null) { }

        public CassetteForm(Cassette cassette)
        {
            _cassette = cassette;
            InitializeComponent();
        }

        private byte[] _imageData;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_cassette != null)
            {
                Text = "Редактиране на касета";
                lblTitle.Text = "Редактиране на касета";
                txtTitle.Text = _cassette.Title;
                txtDirector.Text = _cassette.Director ?? "";
                txtYear.Text = _cassette.Year?.ToString() ?? "";
                txtGenre.Text = _cassette.Genre ?? "";
                txtDescription.Text = _cassette.Description ?? "";
                if (_cassette.ImageData != null && _cassette.ImageData.Length > 0)
                {
                    _imageData = _cassette.ImageData;
                    using var ms = new MemoryStream(_imageData);
                    picImage.Image = Image.FromStream(ms);
                }
            }
        }

        private void BtnSelectImage_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp|Всички файлове|*.*",
                Title = "Изберете снимка"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            try
            {
                using var img = Image.FromFile(ofd.FileName);
                using var ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                _imageData = ms.ToArray();
                picImage.Image = (Image)img.Clone();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка при зареждане: " + ex.Message, "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var title = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Въведете заглавие на филма.", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            int? year = null;
            if (!string.IsNullOrEmpty(txtYear.Text))
            {
                if (!int.TryParse(txtYear.Text, out var y) || y < 1900 || y > 2100)
                {
                    MessageBox.Show("Въведете валидна година (1900–2100).", "Грешка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtYear.Focus();
                    return;
                }
                year = y;
            }

            if (_cassette != null)
            {
                _cassette.Title = title;
                _cassette.Director = string.IsNullOrWhiteSpace(txtDirector.Text) ? null : txtDirector.Text.Trim();
                _cassette.Year = year;
                _cassette.Genre = string.IsNullOrWhiteSpace(txtGenre.Text) ? null : txtGenre.Text.Trim();
                _cassette.Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim();
                _cassette.ImageData = _imageData;
                Result = _cassette;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            Result = new Cassette
                {
                    Title = title,
                    Director = string.IsNullOrWhiteSpace(txtDirector.Text) ? null : txtDirector.Text.Trim(),
                    Year = year,
                    Genre = string.IsNullOrWhiteSpace(txtGenre.Text) ? null : txtGenre.Text.Trim(),
                    Description = string.IsNullOrWhiteSpace(txtDescription.Text) ? null : txtDescription.Text.Trim(),
                    ImageData = _imageData
                };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
