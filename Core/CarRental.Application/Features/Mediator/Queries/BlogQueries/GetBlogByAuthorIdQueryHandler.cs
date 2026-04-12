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
	public class GetBlogByAuthorIdQueryHandler(IBlogRepository repository) : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResult>>
	{
		public async Task<List<GetBlogByAuthorIdQueryResult>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetAllBlogsWithAuthor();

			return values.Where(x => x.AppUserId == request.Id).Select(x => new GetBlogByAuthorIdQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				CategoryName = x.Category?.Name ?? "Kategorisiz",
				AuthorName = x.AppUser != null ? $"{x.AppUser.Name} {x.AppUser.Surname}" : "Yazar Yok",
				CoverImageUrl = x.CoverImageUrl,
				CreatedAt = x.CreatedAt,
				AppUserId = x.AppUserId
			}).OrderByDescending(x => x.Id).ToList();
		}
	}
}