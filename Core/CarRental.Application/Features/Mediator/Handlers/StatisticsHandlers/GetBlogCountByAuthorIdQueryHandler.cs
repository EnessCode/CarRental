using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.StatisticsResults;
using CarRental.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRental.Application.Features.Mediator.Handlers.StatisticsHandlers
{
	public class GetBlogCountByAuthorIdQueryHandler(IStatisticsRepository repository) : IRequestHandler<GetBlogCountByAuthorIdQuery, GetBlogCountByAuthorIdQueryResult>
	{
		public async Task<GetBlogCountByAuthorIdQueryResult> Handle(GetBlogCountByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var value = await repository.GetBlogCountByAuthorId(request.Id);

			return new GetBlogCountByAuthorIdQueryResult
			{
				BlogCountByAuthorId = value
			};
		}
	}
}