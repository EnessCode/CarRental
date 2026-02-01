using CarRental.Application.Features.CQRS.Commands.BrandCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class CreateBrandCommandHandler(IRepository<Brand> brandRepository)
	{
		public async Task<CreateBrandCommand> Handle(CreateBrandCommand command)
		{
			var brand = new Brand
			{
				Name = command.Name
			};

			await brandRepository.CreateAsync(brand);
			return command;
		}
	}
}