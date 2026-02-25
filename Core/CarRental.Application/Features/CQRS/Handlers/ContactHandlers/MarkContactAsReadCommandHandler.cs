using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class MarkContactAsReadCommandHandler(IRepository<Contact> contactRepository)
	{
		public async Task Handle(int id)
		{
			var value = await contactRepository.GetByIdAsync(id);
			if (value != null)
			{
				value.IsRead = true; 
				await contactRepository.UpdateAsync(value);
			}
		}
	}
}
