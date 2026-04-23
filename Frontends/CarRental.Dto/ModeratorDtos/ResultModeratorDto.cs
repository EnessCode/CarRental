using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.ModeratorDtos
{
	public class ResultModeratorDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
	}
}
