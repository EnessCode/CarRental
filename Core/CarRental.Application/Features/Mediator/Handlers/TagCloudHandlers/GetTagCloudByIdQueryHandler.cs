using CarRental.Application.Common;
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
	public class GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository) : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
	{
		public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(TagCloud), request.Id);
			}

			return new GetTagCloudByIdQueryResult
			{
				Id = value.Id,
				Title = value.Title,
				BlogId = value.BlogId
			};
		}
	}
}