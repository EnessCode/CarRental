using CarRental.Application.Features.Mediator.Queries.BlogQueries;
using CarRental.Application.Features.Mediator.Results.BlogResults;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.BlogInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetLast3BlogsWithAuthorQueryHandler(IBlogRepository blogRepository) : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorQueryResult>>
	{
		public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = await blogRepository.GetLast3BlogsWithAuthor();
			return values.Select(x => new GetLast3BlogsWithAuthorQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				CoverImageUrl = x.CoverImageUrl,
				AuthorId = x.AuthorId,
				CategoryId = x.CategoryId,
				CreatedAt = x.CreatedAt,
				AuthorName = x.Author.Name
			}).ToList();
		}
	}
}
