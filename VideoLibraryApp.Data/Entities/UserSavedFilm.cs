namespace VideoLibraryApp.Data.Entities;

/// <summary>
/// Свързваща таблица за отношение много-към-много между User и Cassette.
/// Означава, че потребител е запазил определен филм.
/// </summary>
public class UserSavedFilm
{
    /// <summary>
    /// ID на потребителя.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Референция към потребителя.
    /// </summary>
    public virtual User User { get; set; } = null!;

    /// <summary>
    /// ID на касетата (филма).
    /// </summary>
    public int CassetteId { get; set; }

    /// <summary>
    /// Референция към касетата.
    /// </summary>
    public virtual Cassette Cassette { get; set; } = null!;

    /// <summary>
    /// Дата и час, когато потребителят е запазил филма.
    /// </summary>
    public DateTime SavedAt { get; set; } = DateTime.UtcNow;
}
