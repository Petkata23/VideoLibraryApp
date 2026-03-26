using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.EntityFrameworkCore;
using VideoLibraryApp.Data;
using VideoLibraryApp.Data.Entities;
using VideoLibraryApp.Data.Security;

namespace VideoLibraryApp
{
    /// <summary>
    /// Добавя първоначални данни за демонстрация на приложението (курсов проект).
    /// </summary>
    internal static class DbSeeder
    {
        /// <summary>
        /// Добавя seed данни само при първоначално създаване на базата (празни таблици Users и Cassettes).
        /// </summary>
        public static void Seed(VideoLibraryDbContext context)
        {
            if (context.Users.Any() || context.Cassettes.Any())
                return;

            SeedUsers(context);
            SeedCassettes(context);
            SeedSavedFilms(context);
        }

        private static void SeedUsers(VideoLibraryDbContext context)
        {
            var users = new[]
            {
                new User { Username = "admin", PasswordHash = PasswordHasher.Hash("admin123"), IsAdmin = true },
                new User { Username = "maria", PasswordHash = PasswordHasher.Hash("maria123"), IsAdmin = false },
                new User { Username = "ivan", PasswordHash = PasswordHasher.Hash("ivan123"), IsAdmin = false },
                new User { Username = "elena", PasswordHash = PasswordHasher.Hash("elena123"), IsAdmin = false }
            };
            foreach (var u in users) context.Users.Add(u);
            context.SaveChanges();
        }

        private static void SeedCassettes(VideoLibraryDbContext context)
        {
            var cassettes = new[]
            {
                new Cassette { Title = "Времераздел", Director = "Димитър Петков", Year = 1988, Genre = "Драма", Description = "Класически български филм за съветската епоха и моралните дилеми на съвременното общество. Младо момче трябва да избира между приятелството и истината." },
                new Cassette { Title = "Козият рог", Director = "Методи Андонов", Year = 1972, Genre = "Исторически", Description = "Епичен филм за българското възраждане. Разказва историята на бай Ганьо и борбата срещу османското владичество в планинско село." },
                new Cassette { Title = "Оркестър без име", Director = "Людмил Кирков", Year = 1982, Genre = "Комедия", Description = "Знаменита българска комедия. Група музиканти се опитват да създадат оркестър, но се сблъскват с абсурдни ситуации." },
                new Cassette { Title = "Тютюн", Director = "Никола Корабов", Year = 2008, Genre = "Драма", Description = "По романа на Димитър Димов. История за тютюневата индустрия в България преди Втората световна война и съдбите на хората." },
                new Cassette { Title = "Задача с неизвестни", Director = "Дочо Боджаков", Year = 1982, Genre = "Трилър", Description = "Напрегнат трилър за учител, който се опитва да разкрие престъпление. Интригуващ сюжет с неочаквани обрати." },
                new Cassette { Title = "Маргарит и Маргарита", Director = "Никола Рударов", Year = 1989, Genre = "Романтична комедия", Description = "Романтична комедия за любовта. Двама хора с еднакви имена се срещат по необичаен начин и животът им се променя." },
                new Cassette { Title = "Трите смъртни гряха", Director = "Здравко Шотра", Year = 1986, Genre = "Криминална драма", Description = "Български криминален филм. Разследването на серия от престъпления води до разкриване на дълбоки тайни." },
                new Cassette { Title = "Вечерите на един владетел", Director = "Людмил Стайков", Year = 2000, Genre = "Драма", Description = "Драматичен филм за властта и изкушенията. Владетелът трябва да прецени между личните си желания и дълга си към народа." },
                new Cassette { Title = "Пътешествие до края на нощта", Director = "Иван Ничев", Year = 2021, Genre = "Драма", Description = "Съвременен български филм. История за човек, който тръгва на пътешествие, за да намери смисъла на живота." },
                new Cassette { Title = "Глория", Director = "Петър Вълчанов", Year = 2016, Genre = "Комедия", Description = "Комедия за средновековна жена, която иска да стане рицар. Сатиричен поглед към стереотипите и обществото." },
                new Cassette { Title = "Под същата кожа", Director = "Светла Цекова", Year = 2017, Genre = "Драма", Description = "Трогателна история за семейство и избор. Майка и дъщеря трябва да се справят с труден избор, който може да ги раздели." },
                new Cassette { Title = "Американски пирог", Director = "Пол Вайц", Year = 1999, Genre = "Комедия", Description = "Класическа тийнейджърска комедия за приятелство и първа любов. Група приятели се заклеват да загубят девствеността си до завършването." }
            };

            foreach (var c in cassettes)
            {
                c.ImageData = CreatePosterImage(c.Title, 200, 300);
                context.Cassettes.Add(c);
            }
            context.SaveChanges();
        }

        private static void SeedSavedFilms(VideoLibraryDbContext context)
        {
            var users = context.Users.ToList();
            var cassettes = context.Cassettes.OrderBy(x => x.Id).ToList();

            var maria = users.FirstOrDefault(u => u.Username == "maria");
            var ivan = users.FirstOrDefault(u => u.Username == "ivan");
            var elena = users.FirstOrDefault(u => u.Username == "elena");

            var saved = new List<UserSavedFilm>();
            if (maria != null)
            {
                saved.Add(new UserSavedFilm { UserId = maria.Id, CassetteId = cassettes[0].Id });
                saved.Add(new UserSavedFilm { UserId = maria.Id, CassetteId = cassettes[1].Id });
                saved.Add(new UserSavedFilm { UserId = maria.Id, CassetteId = cassettes[2].Id });
                saved.Add(new UserSavedFilm { UserId = maria.Id, CassetteId = cassettes[5].Id });
            }
            if (ivan != null)
            {
                saved.Add(new UserSavedFilm { UserId = ivan.Id, CassetteId = cassettes[2].Id });
                saved.Add(new UserSavedFilm { UserId = ivan.Id, CassetteId = cassettes[4].Id });
                saved.Add(new UserSavedFilm { UserId = ivan.Id, CassetteId = cassettes[11].Id });
            }
            if (elena != null)
            {
                saved.Add(new UserSavedFilm { UserId = elena.Id, CassetteId = cassettes[3].Id });
                saved.Add(new UserSavedFilm { UserId = elena.Id, CassetteId = cassettes[9].Id });
            }

            foreach (var s in saved)
                context.UserSavedFilms.Add(s);
            context.SaveChanges();
        }

        /// <summary>
        /// Генерира постър за касета – градиент със заглавие, подходящ за демонстрация.
        /// </summary>
        private static byte[] CreatePosterImage(string title, int width, int height)
        {
            using var bmp = new Bitmap(width, height);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Градиент – тъмно синьо до лилаво (в стила на приложението)
            using (var brush = new LinearGradientBrush(
                new Rectangle(0, 0, width, height),
                Color.FromArgb(22, 30, 48),
                Color.FromArgb(60, 40, 80),
                LinearGradientMode.ForwardDiagonal))
            {
                g.FillRectangle(brush, 0, 0, width, height);
            }

            // Рамка
            using (var pen = new Pen(Color.FromArgb(80, 255, 200, 100), 2))
                g.DrawRectangle(pen, 1, 1, width - 2, height - 2);

            // Икона или буква
            var firstChar = string.IsNullOrEmpty(title) ? "?" : title.Trim()[0].ToString().ToUpperInvariant();
            using (var font = new Font("Segoe UI", 72, FontStyle.Bold))
            using (var textBrush = new SolidBrush(Color.FromArgb(255, 200, 100)))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString(firstChar, font, textBrush, new RectangleF(0, 0, width, height - 60), sf);
            }

            // Заглавие (първите 2 реда)
            var words = title.Split(' ');
            var line1 = "";
            var line2 = "";
            foreach (var w in words)
            {
                if (string.IsNullOrEmpty(line1)) line1 = w;
                else if ((line1 + " " + w).Length <= 18) line1 += " " + w;
                else if (string.IsNullOrEmpty(line2)) line2 = w;
                else if ((line2 + " " + w).Length <= 18) line2 += " " + w;
                else break;
            }
            if (string.IsNullOrEmpty(line2) && !string.IsNullOrEmpty(line1) && line1.Length > 18)
            {
                var idx = line1.LastIndexOf(' ');
                if (idx > 0) { line2 = line1.Substring(idx + 1); line1 = line1.Substring(0, idx); }
            }

            using (var font = new Font("Segoe UI", 10, FontStyle.Regular))
            using (var textBrush = new SolidBrush(Color.FromArgb(220, 220, 235)))
            {
                var sf = new StringFormat { Alignment = StringAlignment.Center };
                g.DrawString(line1, font, textBrush, new RectangleF(0, height - 55, width, 20), sf);
                if (!string.IsNullOrEmpty(line2))
                    g.DrawString(line2, font, textBrush, new RectangleF(0, height - 38, width, 20), sf);
            }

            using var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}
