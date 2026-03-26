using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using VideoLibraryApp.Data;

namespace VideoLibraryApp
{
    internal static class Program
    {
        /// <summary>
        /// Точка на влизане на приложението.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Инициализация на AutoMapper (lazy при първо ползване)
            _ = MapperProvider.Mapper;

            // Прилагане на миграции при стартиране – създава/актуализира базата данни
            using (var context = DbContextFactory.Create())
            {
                context.Database.Migrate();
                DbSeeder.Seed(context);
            }

            Application.Run(new LoginForm());
        }
    }
}
