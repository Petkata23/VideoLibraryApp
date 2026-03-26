namespace VideoLibraryApp.Shared.Dtos;

/// <summary>
/// DTO за касета – използва се при представяне в UI.
/// </summary>
public class CassetteDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int? Year { get; set; }
    public string Genre { get; set; } = string.Empty;
    public byte[] ImageData { get; set; }
}
