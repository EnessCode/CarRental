using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.CategoryCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
	{
		public async Task<UpdateCategoryCommand> Handle(UpdateCategoryCommand command)
		{
			var value = await categoryRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Category), command.Id);
			}

			value.Name = command.Name;
			await categoryRepository.UpdateAsync(value);
			return command;
		}
	}
}
