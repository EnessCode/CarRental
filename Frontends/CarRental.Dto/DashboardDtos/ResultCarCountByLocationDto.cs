using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.DashboardDtos
{
	public class ResultCarCountByLocationDto
	{
		public string LocationName { get; set; }
		public int CarCount { get; set; }
	}
}
