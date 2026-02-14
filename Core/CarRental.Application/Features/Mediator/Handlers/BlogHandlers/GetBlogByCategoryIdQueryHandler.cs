using CarRental.Application.Features.Mediator.Queries.BlogQueries;
using CarRental.Application.Features.Mediator.Results.BlogResults;
using CarRental.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogByCategoryIdQueryHandler(IBlogRepository blogRepository) : IRequestHandler<GetBlogByCategoryIdQuery, List<GetBlogByCategoryIdQueryResult>>
	{
		public async Task<List<GetBlogByCategoryIdQueryResult>> Handle(GetBlogByCategoryIdQuery request, CancellationToken cancellationToken)
		{
			var values = await blogRepository.GetBlogsByCategoryId(request.Id);
			return values.Select(x => new GetBlogByCategoryIdQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				CoverImageUrl = x.CoverImageUrl,
				AuthorName = x.Author.Name,
				AuthorDescription = x.Author.Description,
				AuthorImageUrl = x.Author.ImageUrl,
				CreatedAt = x.CreatedAt,
				CategoryId = x.CategoryId,
				CategoryName = x.Category.Name
			}).ToList();
		}
	}
}
