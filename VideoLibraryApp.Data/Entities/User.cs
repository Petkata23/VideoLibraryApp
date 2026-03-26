namespace VideoLibraryApp.Data.Entities;

/// <summary>
/// Потребител в системата на видеотеката.
/// Може да бъде администратор или обикновен потребител.
/// </summary>
public class User : BaseEntity
{
    /// <summary>
    /// Потребителско име за вход.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Хеширана парола (никога не се съхранява в чист вид).
    /// </summary>
    public string PasswordHash { get; set; } = string.Empty;

    /// <summary>
    /// Дали потребителят има права на администратор.
    /// Само администраторите могат да добавят, редактират и изтриват касети и потребители.
    /// </summary>
    public bool IsAdmin { get; set; }

    /// <summary>
    /// Списък с филми, запазени от потребителя.
    /// </summary>
    public virtual ICollection<UserSavedFilm> SavedFilms { get; set; } = new List<UserSavedFilm>();
}
