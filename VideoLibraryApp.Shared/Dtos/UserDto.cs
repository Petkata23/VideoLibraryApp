namespace VideoLibraryApp.Shared.Dtos;

/// <summary>
/// DTO за потребител – използва се при представяне в UI (списък в таблица).
/// </summary>
public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public bool IsAdmin { get; set; }
}
