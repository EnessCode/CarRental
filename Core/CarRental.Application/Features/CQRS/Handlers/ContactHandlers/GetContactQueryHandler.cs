using CarRental.Application.Features.CQRS.Results.ContactResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactQueryHandler(IRepository<Contact> contactRepository)
	{
		public async Task<List<GetContactQueryResult>> Handle()
		{
			var values = await contactRepository.GetAllAsync();
			return values.Select(x => new GetContactQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Email = x.Email,
				Subject = x.Subject,
				Message = x.Message,
				SendDate = x.SendDate
			}).ToList();
		}
	}
}
