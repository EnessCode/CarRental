using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.ContactCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class RemoveContactCommandHandler(IRepository<Contact> contactRepository)
	{
		public async Task<RemoveContactCommand> Handle(RemoveContactCommand command)
		{
			var value = await contactRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Contact), command.Id);
			}

			await contactRepository.RemoveAsync(value);

			return command;
		}
	}
}
