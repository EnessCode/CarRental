using CarRental.Application.Features.CQRS.Commands.ContactCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class CreateContactCommandHandler(IRepository<Contact> contactRepository)
	{
		public async Task<CreateContactCommand> Handle(CreateContactCommand Command)
		{
			var contact = new Contact
			{
				Name = Command.Name,
				Email = Command.Email,
				Subject = Command.Subject,
				Message = Command.Message,
				SendDate = Command.SendDate
			};

			await contactRepository.CreateAsync(contact);
			return Command;
		}
	}
}
