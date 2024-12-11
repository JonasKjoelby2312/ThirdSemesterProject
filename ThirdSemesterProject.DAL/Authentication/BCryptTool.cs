using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ThirdSemesterProject.DAL.Authentication;

/// <summary>
/// This class is used for hashing, salting and validating passwords.
/// </summary>
public static class BCryptTool
{
    /// <summary>
    /// Generates a salt value for the password.
    /// </summary>
    /// <returns>A random generated salt.</returns>
    private static string GetRandomSalt() => BCrypt.Net.BCrypt.GenerateSalt(12);

    /// <summary>
    /// This method hashes the password using BCrypt.
    /// </summary>
    /// <param name="password">The entered password that will be hashed.</param>
    /// <returns>A hashed password</returns>
    public static string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
    /// <summary>
    /// This method is for validating a password.
    /// </summary>
    /// <param name="password">The password in normal text.</param>
    /// <param name="correctHash">The hashed password to validate</param>
    /// <returns>true if the password matches the hashed one, if it is not matching it will be fals</returns>
    public static bool ValidatePassword(string password, string correctHash) => BCrypt.Net.BCrypt.Verify(password, correctHash);
}
