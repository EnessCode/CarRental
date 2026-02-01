using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Commands.ContactCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class UpdateContactCommandHandler(IRepository<Contact> aboutRepository)
	{
		public async Task<UpdateContactCommand> Handle(UpdateContactCommand command)
		{
			var value = await aboutRepository.GetByIdAsync(command.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Contact), command.Id);
			}

			value.Name = command.Name;
			value.Email = command.Email;
			value.Subject = command.Subject;
			value.Message = command.Message;
			value.SendDate = command.SendDate;

			await aboutRepository.UpdateAsync(value);
			return command;
		}
	}
}
