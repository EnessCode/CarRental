using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Queries.CarQueries;
using CarRental.Application.Features.CQRS.Results.CarResults;
using CarRental.Application.Interfaces.CarInterfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CarHandlers
{
	public class GetCarWithBrandByIdQueryHandler(ICarRepository carRepository)
	{
		public async Task<GetCarWithBrandByIdQueryResult> Handle(GetCarByIdQuery query)
		{
			var value = await carRepository.GetCarWithBrandById(query.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Car), query.Id);
			}

			return new GetCarWithBrandByIdQueryResult
			{
				Id = value.Id,
				BrandName = value.Brand.Name,
				Model = value.Model,
				CoverImageUrl = value.CoverImageUrl
			};
		}
	}
}
