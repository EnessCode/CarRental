using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.StatisticsResults;
using CarRental.Application.Interfaces.StatisticsInterfaces;
using MediatR;

namespace CarRental.Application.Features.Mediator.Handlers.StatisticsHandlers
{
	public class GetTotalCommentCountByAuthorIdQueryHandler(IStatisticsRepository repository) : IRequestHandler<GetTotalCommentCountByAuthorIdQuery, GetTotalCommentCountByAuthorIdQueryResult>
	{
		public async Task<GetTotalCommentCountByAuthorIdQueryResult> Handle(GetTotalCommentCountByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var value = await repository.GetTotalCommentCountByAuthorId(request.Id);

			return new GetTotalCommentCountByAuthorIdQueryResult
			{
				TotalCommentCountByAuthorId = value
			};
		}
	}
}