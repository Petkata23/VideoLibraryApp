namespace VideoLibraryApp.Shared.Dtos;

/// <summary>
/// DTO за запазен филм – касета + дата на запазване.
/// Използва се в Моите филми.
/// </summary>
public class SavedFilmDto
{
    public CassetteDto Cassette { get; set; } = null!;
    public DateTime SavedAt { get; set; }
}
