using CarRental.Application.Common;
using CarRental.Application.Features.CQRS.Queries.AboutQueries;
using CarRental.Application.Features.CQRS.Queries.ContactQueries;
using CarRental.Application.Features.CQRS.Results.AboutResults;
using CarRental.Application.Features.CQRS.Results.ContactResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;

namespace CarRental.Application.Features.CQRS.Handlers.ContactHandlers
{
	public class GetContactByIdQueryHandler(IRepository<Contact> contactRepository)
	{
		public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
		{
			var value = await contactRepository.GetByIdAsync(query.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Contact), query.Id);
			}

			return new GetContactByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name,
				Email = value.Email,
				Subject = value.Subject,
				Message = value.Message,
				SendDate = value.SendDate
			};
		}
	}
}
