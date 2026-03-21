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
	public class GetLast5BlogsWithAuthorQueryHandler(IBlogRepository repository) : IRequestHandler<GetLast5BlogsWithAuthorQuery, List<GetLast5BlogsWithAuthorQueryResult>>
	{
		public async Task<List<GetLast5BlogsWithAuthorQueryResult>> Handle(GetLast5BlogsWithAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetLast5BlogsWithAuthors();

			return values.Select(x => new GetLast5BlogsWithAuthorQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				AuthorName = x.Author.Name, 
				CategoryName = x.Category.Name, 
				CoverImageUrl = x.CoverImageUrl,
				CreatedAt = x.CreatedAt
			}).ToList();
		}
	}
}
