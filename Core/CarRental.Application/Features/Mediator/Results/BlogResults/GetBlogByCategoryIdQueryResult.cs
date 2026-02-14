using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Results.BlogResults
{
	public class GetBlogByCategoryIdQueryResult
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string AuthorName { get; set; }
		public string AuthorDescription { get; set; }
		public string AuthorImageUrl { get; set; }
		public string CoverImageUrl { get; set; }
		public DateTime CreatedAt { get; set; }
		public int CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}
