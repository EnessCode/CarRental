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
	public class GetBlogDetailsQueryHandler(IBlogRepository blogRepository) : IRequestHandler<GetBlogDetailsQuery, GetBlogDetailsQueryResult>
	{
		public async Task<GetBlogDetailsQueryResult> Handle(GetBlogDetailsQuery request, CancellationToken cancellationToken)
		{
			var values = await blogRepository.GetBlogWithAuthorAndCategoryByBlogId(request.Id);

			if (values == null)
			{
				return new GetBlogDetailsQueryResult();
			}

			return new GetBlogDetailsQueryResult
			{
				Id = values.Id,
				Title = values.Title,
				Description = values.Description,
				CoverImageUrl = values.CoverImageUrl,
				CreatedAt = values.CreatedAt,
				AuthorId = values.AuthorId,
				AuthorName = values.Author.Name,
				AuthorDescription = values.Author.Description,
				AuthorImageUrl = values.Author.ImageUrl,   
				CategoryId = values.CategoryId,
				CategoryName = values.Category.Name
			};
		}
	}
}
