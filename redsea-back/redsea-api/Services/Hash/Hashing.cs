using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace redsea_api.Services.Hash;

public record HashResult(string Hash, string Salt);

public static class Hashing
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 4;
    private const int MemorySize = 65536;
    private const int Parallelism = 4;
    
    public static HashResult GenerateHash(string input)
    {
        var rng = RandomNumberGenerator.Create();
        
        var salt = new byte[SaltSize];

        rng.GetBytes(salt);
        
        var hash = ComputeHash(input, salt);
        
        var hashResult = new HashResult(Convert.ToBase64String(hash), Convert.ToBase64String(salt));
        
        return hashResult;
    }
    
    public static bool VerifyHash(string input, string storedHash, string storedSalt)
    {
        var saltBytes = Convert.FromBase64String(storedSalt);
        var hashBytes = Convert.FromBase64String(storedHash);
        
        var computedHash = ComputeHash(input, saltBytes);
        
        // Constant-time comparison to prevent timing attacks
        return CryptographicOperations.FixedTimeEquals(computedHash, hashBytes);
    }

    private static byte[] ComputeHash(string input, byte[] salt)
    {
        var stringToHashBytes = Encoding.UTF8.GetBytes(input);
        
        var argon2 = new Argon2id(stringToHashBytes)
        {
            Salt = salt,
            DegreeOfParallelism = Parallelism,
            Iterations = Iterations,
            MemorySize = MemorySize
        };
        
        return argon2.GetBytes(HashSize) ?? throw new Exception("Hashing failed");
    }
}