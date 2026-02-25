using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Dto.CommentDtos
{
	public class ResultCommentDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Description { get; set; }
		public string BlogTitle { get; set; }
		public int BlogId { get; set; }
	}
}
