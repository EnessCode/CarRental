using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.BrandCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.BrandHandlers
{
	public class RemoveBrandCommandHandler(IRepository<Brand> brandRepository)
	{
		public async Task<RemoveBrandCommand> Handle(RemoveBrandCommand command)
		{
			var value = await brandRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Brand), command.Id);
			}

			await brandRepository.RemoveAsync(value);

			return command;
		}
	}
}