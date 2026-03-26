using System.Security.Cryptography;

namespace VideoLibraryApp.Data.Security;

/// <summary>
/// Хешира и проверява пароли чрез PBKDF2 със SHA-256.
/// Паролите никога не се съхраняват в чист вид.
/// </summary>
public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 100000;
    private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA256;

    /// <summary>
    /// Хешира паролата и връща низ във формат salt + hash (Base64).
    /// </summary>
    public static string Hash(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(password));

        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

        byte[] result = new byte[SaltSize + HashSize];
        Buffer.BlockCopy(salt, 0, result, 0, SaltSize);
        Buffer.BlockCopy(hash, 0, result, SaltSize, HashSize);

        return Convert.ToBase64String(result);
    }

    /// <summary>
    /// Проверява дали подадената парола съвпада с хешираната.
    /// </summary>
    public static bool Verify(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword))
            return false;

        try
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            if (hashBytes.Length != SaltSize + HashSize)
                return false;

            byte[] salt = new byte[SaltSize];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);

            byte[] expectedHash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

            return CryptographicOperations.FixedTimeEquals(expectedHash, hashBytes.AsSpan(SaltSize));
        }
        catch
        {
            return false;
        }
    }
}
