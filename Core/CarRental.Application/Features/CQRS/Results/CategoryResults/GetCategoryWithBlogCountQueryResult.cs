using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.CQRS.Results.CategoryResults
{
	public class GetCategoryWithBlogCountQueryResult
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int BlogCount { get; set; }
	}
}
