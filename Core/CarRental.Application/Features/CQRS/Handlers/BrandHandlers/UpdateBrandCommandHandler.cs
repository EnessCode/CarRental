using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.BrandCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class UpdateBrandCommandHandler(IRepository<Brand> brandRepository)
	{
		public async Task<UpdateBrandCommand> Handle(UpdateBrandCommand command)
		{
			var value = await brandRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Brand), command.Id);
			}

			value.Name = command.Name;
			await brandRepository.UpdateAsync(value);
			return command;
		}
	}
}