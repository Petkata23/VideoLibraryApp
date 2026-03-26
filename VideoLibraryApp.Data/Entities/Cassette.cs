namespace VideoLibraryApp.Data.Entities;

/// <summary>
/// Касета (филм) във видеотеката.
/// </summary>
public class Cassette : BaseEntity
{
    /// <summary>
    /// Заглавие на филма.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Режисьор на филма.
    /// </summary>
    public string? Director { get; set; }

    /// <summary>
    /// Година на издаване.
    /// </summary>
    public int? Year { get; set; }

    /// <summary>
    /// Жанр (екшън, комедия, драма и т.н.).
    /// </summary>
    public string? Genre { get; set; }

    /// <summary>
    /// Описание на филма.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Снимка/постер на касетата (опционално).
    /// </summary>
    public byte[]? ImageData { get; set; }

    /// <summary>
    /// Потребители, които са запазили този филм.
    /// </summary>
    public virtual ICollection<UserSavedFilm> SavedByUsers { get; set; } = new List<UserSavedFilm>();
}
