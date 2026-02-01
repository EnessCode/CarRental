using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.CategoryCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class RemoveCategoryCommandHandler(IRepository<Category> categoryRepository)
	{
		public async Task<RemoveCategoryCommand> Handle(RemoveCategoryCommand command)
		{
			var value = await categoryRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Category), command.Id);
			}

			await categoryRepository.RemoveAsync(value);

			return command;
		}
	}
}
