namespace VideoLibraryApp.Data.Entities;

/// <summary>
/// Базова сущност за всички entities в системата.
/// Съдържа общи свойства като Id, дати на създаване/актуализация и soft delete.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Уникален идентификатор на записа.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Дата и час на създаване на записа.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Дата и час на последна актуализация. Null ако никога не е променян.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Флаг за soft delete – записът не се изтрива физически, само се маркира като изтрит.
    /// </summary>
    public bool IsDeleted { get; set; }
}
