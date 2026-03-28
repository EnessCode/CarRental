using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarRental.Application.Features.Mediator.Results.CarDescriptionResults;
using CarRental.Application.Interfaces.CarDescriptionInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository _carDescriptionRepository) : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionQueryResult>
	{
		public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _carDescriptionRepository.GetCarDescription(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(CarDescription), request.Id);
			}

			return new GetCarDescriptionQueryResult
			{
				Id = value.Id,
				CarId = value.CarId,
				Details = value.Details
			};
		}
	}
}