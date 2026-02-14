using CarRental.Application.Features.CQRS.Results.CategoryResults;
using CarRental.Application.Interfaces.CategoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class GetCategoryWithBlogCountQueryHandler(ICategoryRepository categoryRepository)
	{
		public async Task<List<GetCategoryWithBlogCountQueryResult>> Handle()
		{
			var values = await categoryRepository.GetCategoriesWithBlogs();
			return values.Select(x => new GetCategoryWithBlogCountQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				BlogCount = x.Blogs.Count
			}).ToList();
		}
	}
}
