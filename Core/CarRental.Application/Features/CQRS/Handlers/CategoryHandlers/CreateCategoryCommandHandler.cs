using CarRental.Application.Features.CQRS.Commands.CategoryCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.CategoryHandlers
{
	public class CreateCategoryCommandHandler(IRepository<Category> categoryRepository)
	{
		public async Task<CreateCategoryCommand> Handle(CreateCategoryCommand command)
		{
			var category = new Category
			{
				Name = command.Name
			};

			await categoryRepository.CreateAsync(category);
			return command;
		}
	}
}
