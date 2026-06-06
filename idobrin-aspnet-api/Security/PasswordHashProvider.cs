using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace idobrin_aspnet_api.Security;

public class PasswordHashProvider
{
    public static string GetSalt()
    {
        var salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
        var b64Salt = Convert.ToBase64String(salt);

        return b64Salt;
    }

    public static string GetHash(string password, string b64salt)
    {
        var salt = Convert.FromBase64String(b64salt);

        var hash =
            KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 131072,
                numBytesRequested: 256 / 8);
        var b64Hash = Convert.ToBase64String(hash);

        return b64Hash;
    }
}