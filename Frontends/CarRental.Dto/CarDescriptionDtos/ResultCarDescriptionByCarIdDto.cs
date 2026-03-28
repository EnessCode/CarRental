using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.CarDescriptionDtos
{
	public class ResultCarDescriptionByCarIdDto
	{
		public int Id { get; set; }
		public int CarId { get; set; }
		public string Details { get; set; }
	}
}
