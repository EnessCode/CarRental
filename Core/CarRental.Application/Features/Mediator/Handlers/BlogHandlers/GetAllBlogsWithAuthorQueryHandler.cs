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
	public class GetAllBlogsWithAuthorQueryHandler(IBlogRepository blogRepository) : IRequestHandler<GetAllBlogsWithAuthorQuery, List<GetAllBlogsWithAuthorQueryResult>>
	{
		public async Task<List<GetAllBlogsWithAuthorQueryResult>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = await blogRepository.GetAllBlogsWithAuthor();
			return values.Select(x => new GetAllBlogsWithAuthorQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				AuthorName = x.Author.Name,
				AuthorId = x.AuthorId,
				CategoryId = x.CategoryId,
				CategoryName = x.Category.Name,
				CoverImageUrl = x.CoverImageUrl,
				CreatedAt = x.CreatedAt
			}).ToList();
		}
	}
}
