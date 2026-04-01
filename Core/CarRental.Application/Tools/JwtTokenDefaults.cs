using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudience = "Jwt:Audience";
		public const string ValidIssuer = "Jwt:Issuer";
		public const string SecretKey = "Jwt:SecretKey";
		public const int ExpireDays = 3;
	}
}
