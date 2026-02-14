using CarRental.Application.Features.Mediator.Queries.TagCloudQueries;
using CarRental.Application.Features.Mediator.Results.TagCloudResults;
using CarRental.Application.Interfaces.TagCloudInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository) : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
	{
		public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetTagCloudsByBlogId(request.Id);
			return values.Select(x => new GetTagCloudByBlogIdQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				BlogId = x.BlogId
			}).ToList();
		}
	}
}
