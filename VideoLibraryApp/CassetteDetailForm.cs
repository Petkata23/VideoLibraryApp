using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VideoLibraryApp.Data.Entities;

namespace VideoLibraryApp
{
    /// <summary>
    /// Форма за преглед на пълните данни на касета – постер, заглавие, описание и т.н.
    /// </summary>
    public partial class CassetteDetailForm : Form
    {
        public CassetteDetailForm(Cassette cassette)
        {
            InitializeComponent();
            LoadCassette(cassette);
        }

        private void LoadCassette(Cassette c)
        {
            lblTitle.Text = c.Title;
            lblDirectorVal.Text = string.IsNullOrEmpty(c.Director) ? "-" : c.Director;
            lblYearVal.Text = (c.Year ?? 0) > 0 ? c.Year.ToString() : "-";
            lblGenreVal.Text = string.IsNullOrEmpty(c.Genre) ? "-" : c.Genre;
            txtDescription.Text = string.IsNullOrEmpty(c.Description) ? "Няма описание." : c.Description;
            txtDescription.SelectionStart = 0;
            txtDescription.SelectionLength = 0;

            if (c.ImageData != null && c.ImageData.Length > 0)
            {
                try
                {
                    using var ms = new MemoryStream(c.ImageData);
                    picPoster.Image = (Image)Image.FromStream(ms).Clone();
                    lblNoImage.Visible = false;
                }
                catch
                {
                    picPoster.Image = null;
                    lblNoImage.Visible = true;
                }
            }
            else
            {
                picPoster.Image = null;
                lblNoImage.Visible = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
