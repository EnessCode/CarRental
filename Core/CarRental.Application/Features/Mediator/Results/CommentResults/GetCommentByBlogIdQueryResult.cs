using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Results.CommentResults
{
	public class GetCommentByBlogIdQueryResult
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedDate { get; set; }
		public string Description { get; set; }
		public string BlogTitle { get; set; }
		public int BlogId { get; set; }
		public Blog Blog { get; set; }
	}
}
