using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CarRental.Application.Tools
{
	public static class PasswordHashHelper
	{
		public static string HashPassword(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(bytes);
			}
		}

		public static bool VerifyPassword(string password, string hashedPassword)
		{
			var hashOfInput = HashPassword(password);
			return hashOfInput == hashedPassword;
		}
	}
}
