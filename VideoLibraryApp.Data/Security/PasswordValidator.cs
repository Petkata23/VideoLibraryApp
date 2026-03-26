namespace VideoLibraryApp.Data.Security;

/// <summary>
/// Валидация на парола при регистрация.
/// </summary>
public static class PasswordValidator
{
    /// <summary>
    /// Минимална дължина на паролата.
    /// </summary>
    public const int MinLength = 6;

    /// <summary>
    /// Максимална дължина на паролата.
    /// </summary>
    public const int MaxLength = 100;

    /// <summary>
    /// Валидира паролата. Връща празен string ако е валидна, иначе съобщение за грешка.
    /// </summary>
    public static string Validate(string password)
    {
        if (string.IsNullOrEmpty(password))
            return "Въведете парола.";

        if (password.Length < MinLength)
            return $"Паролата трябва да е поне {MinLength} символа.";

        if (password.Length > MaxLength)
            return $"Паролата не трябва да надвишава {MaxLength} символа.";

        if (!password.Any(char.IsLetter))
            return "Паролата трябва да съдържа поне една буква.";

        if (!password.Any(char.IsDigit))
            return "Паролата трябва да съдържа поне една цифра.";

        return string.Empty;
    }
}
