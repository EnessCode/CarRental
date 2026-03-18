using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.CarFeatureDtos
{
	public class ResultCarFeatureByCarIdDto
	{
		public int Id { get; set; }
		public int CarId { get; set; }
		public int FeatureId { get; set; }
		public string FeatureName { get; set; }
		public bool Available { get; set; }
	}
}
