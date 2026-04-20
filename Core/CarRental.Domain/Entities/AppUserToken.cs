using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Entities
{
	public class AppUserToken
	{
		public int Id { get; set; }
		public string Token { get; set; }
		public DateTime ExpireDate { get; set; }
		public int AppUserId { get; set; }
		public AppUser AppUser { get; set; }
	}
}
