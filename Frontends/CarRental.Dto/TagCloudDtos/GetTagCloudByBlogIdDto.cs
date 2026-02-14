using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.TagCloudDtos
{
	public class GetTagCloudByBlogIdDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int BlogId { get; set; }
	}
}
