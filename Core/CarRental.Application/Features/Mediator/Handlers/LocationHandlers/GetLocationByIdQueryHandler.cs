using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.LocationQueries;
using CarRental.Application.Features.Mediator.Results.LocationResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.LocationHandlers
{
	public class GetLocationByIdQueryHandler(IRepository<Location> repository) : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
	{
		public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Location), request.Id);
			}

			return new GetLocationByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name
			};
		}
	}
}