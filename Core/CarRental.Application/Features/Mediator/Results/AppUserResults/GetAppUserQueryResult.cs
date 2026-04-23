using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Results.AppUserResults
{
	public class GetAppUserQueryResult
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string RoleName { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
	}
}
