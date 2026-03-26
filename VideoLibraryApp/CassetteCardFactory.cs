using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VideoLibraryApp.Shared.Dtos;

namespace VideoLibraryApp
{
    /// <summary>
    /// Обща фабрика за карти с касети (каталог и „Моите филми“).
    /// </summary>
    public static class CassetteCardFactory
    {
        private static readonly Color CardBack = Color.FromArgb(35, 45, 65);
        private static readonly Color PicBack = Color.FromArgb(45, 55, 80);
        private static readonly Color TitleColor = Color.FromArgb(255, 200, 100);
        private static readonly Color InfoColor = Color.FromArgb(180, 190, 210);

        public static Panel CreateCard(
            CassetteDto c,
            int w,
            int h,
            bool isAdmin,
            Action<int> onViewDetails,
            Action<int> onSave,
            Action<int> onEdit = null,
            Action<int> onDelete = null)
        {
            var panel = CreateCardPanel(w, h);

            const int picH = 220;
            var pic = CreatePosterPicture(c, w, picH, new Point(8, 8), c.Id,
                (_, _) => onViewDetails(c.Id));
            panel.Controls.Add(pic);

            var lblTitle = CreateTitleLabel(c, w, 235, c.Id, (_, _) => onViewDetails(c.Id));
            panel.Controls.Add(lblTitle);

            var lblInfo = CreateInfoLabel(c, w, 255, 35, c.Id, (_, _) => onViewDetails(c.Id));
            panel.Controls.Add(lblInfo);

            var btnSave = new Button
            {
                Text = "\u2764 Запази",
                Size = new Size(w - 16, 32),
                Location = new Point(8, 292),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(80, 60, 60),
                ForeColor = Color.FromArgb(255, 180, 180),
                Cursor = Cursors.Hand,
                Tag = c.Id
            };
            btnSave.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 80);
            btnSave.Click += (_, _) => onSave(c.Id);
            panel.Controls.Add(btnSave);

            if (isAdmin && onEdit != null && onDelete != null)
            {
                var btnEdit = new Button
                {
                    Text = "Редактирай",
                    Size = new Size(92, 28),
                    Location = new Point(8, 328),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(50, 60, 80),
                    ForeColor = TitleColor,
                    Cursor = Cursors.Hand,
                    Tag = c.Id
                };
                btnEdit.Click += (_, _) => onEdit(c.Id);
                panel.Controls.Add(btnEdit);

                var btnDelete = new Button
                {
                    Text = "Изтрий",
                    Size = new Size(92, 28),
                    Location = new Point(8 + 96, 328),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(70, 45, 45),
                    ForeColor = Color.FromArgb(255, 180, 180),
                    Cursor = Cursors.Hand,
                    Tag = c.Id
                };
                btnDelete.Click += (_, _) => onDelete(c.Id);
                panel.Controls.Add(btnDelete);
            }

            return panel;
        }

        /// <summary>
        /// Карта за „Моите филми“ – премахване от запазени вместо „Запази“.
        /// </summary>
        public static Panel CreateSavedFilmCard(
            SavedFilmDto item,
            int w,
            int h,
            Action<SavedFilmDto> onViewDetails,
            Action<int> onRemove)
        {
            var c = item.Cassette;
            var panel = CreateCardPanel(w, h);

            const int picH = 210;
            var pic = CreatePosterPicture(c, w, picH, new Point(8, 8), item,
                (_, _) => onViewDetails(item));
            panel.Controls.Add(pic);

            var lblTitle = CreateTitleLabel(c, w, 223, item, (_, _) => onViewDetails(item));
            panel.Controls.Add(lblTitle);

            var lblInfo = CreateInfoLabel(c, w, 243, 30, item, (_, _) => onViewDetails(item));
            panel.Controls.Add(lblInfo);

            var btnRemove = new Button
            {
                Text = "Премахни от запазени",
                Size = new Size(w - 16, 32),
                Location = new Point(8, 275),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(70, 45, 45),
                ForeColor = Color.FromArgb(255, 180, 180),
                Cursor = Cursors.Hand,
                Tag = c.Id
            };
            btnRemove.FlatAppearance.BorderColor = Color.FromArgb(120, 80, 80);
            btnRemove.Click += (_, _) => onRemove(c.Id);
            panel.Controls.Add(btnRemove);

            return panel;
        }

        private static Panel CreateCardPanel(int w, int h)
        {
            return new Panel
            {
                Size = new Size(w, h),
                Margin = new Padding(12),
                BackColor = CardBack,
                Padding = new Padding(0),
                BorderStyle = BorderStyle.None
            };
        }

        private static PictureBox CreatePosterPicture(
            CassetteDto c,
            int w,
            int picHeight,
            Point location,
            object tag,
            EventHandler click)
        {
            var pic = new PictureBox
            {
                Size = new Size(w - 16, picHeight),
                Location = location,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = PicBack,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = tag
            };
            pic.Click += click;
            if (c.ImageData != null && c.ImageData.Length > 0)
            {
                try
                {
                    using var ms = new MemoryStream(c.ImageData);
                    pic.Image = (Image)Image.FromStream(ms).Clone();
                }
                catch
                {
                    pic.Image = null;
                }
            }

            if (pic.Image == null)
            {
                pic.Controls.Add(new Label
                {
                    Text = "Няма снимка",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point((w - 16) / 2 - 40, picHeight / 2 - 10)
                });
            }

            return pic;
        }

        private static Label CreateTitleLabel(CassetteDto c, int w, int y, object tag, EventHandler click)
        {
            var text = (c.Title?.Length ?? 0) > 25 ? c.Title.Substring(0, 22) + "..." : (c.Title ?? "-");
            var lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = TitleColor,
                Location = new Point(8, y),
                Size = new Size(w - 16, 22),
                AutoEllipsis = true,
                Cursor = Cursors.Hand,
                Tag = tag
            };
            lbl.Click += click;
            return lbl;
        }

        private static Label CreateInfoLabel(CassetteDto c, int w, int y, int height, object tag, EventHandler click)
        {
            var lbl = new Label
            {
                Text = c.Director + " | " + ((c.Year ?? 0) > 0 ? c.Year.ToString() : "-") + " | " + c.Genre,
                Font = new Font("Segoe UI", 8),
                ForeColor = InfoColor,
                Location = new Point(8, y),
                Size = new Size(w - 16, height),
                AutoEllipsis = true,
                Cursor = Cursors.Hand,
                Tag = tag
            };
            lbl.Click += click;
            return lbl;
        }
    }
}
