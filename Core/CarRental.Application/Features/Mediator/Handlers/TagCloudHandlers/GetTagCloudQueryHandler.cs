using CarRental.Application.Features.Mediator.Queries.TagCloudQueries;
using CarRental.Application.Features.Mediator.Results.TagCloudResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.TagCloudHandlers
{
	public class GetTagCloudQueryHandler(IRepository<TagCloud> repository) : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
	{
		public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetAllAsync();
			return values.Select(x => new GetTagCloudQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				BlogId = x.BlogId
			}).ToList();
		}
	}
}