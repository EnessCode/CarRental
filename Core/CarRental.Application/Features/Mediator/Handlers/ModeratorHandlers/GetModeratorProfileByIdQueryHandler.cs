using CarRental.Application.Features.Mediator.Queries.ModeratorQueries;
using CarRental.Application.Features.Mediator.Results.ModeratorResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.ModeratorHandlers
{
	public class GetModeratorProfileByIdQueryHandler(IRepository<AppUser> repository) : IRequestHandler<GetModeratorProfileByIdQuery, GetModeratorProfileByIdQueryResult>
	{
		public async Task<GetModeratorProfileByIdQueryResult> Handle(GetModeratorProfileByIdQuery request, CancellationToken cancellationToken)
		{
			var user = await repository.GetByIdAsync(request.Id);
			if (user == null) return null;

			return new GetModeratorProfileByIdQueryResult
			{
				AppUserId = user.Id,
				Name = user.Name,
				Surname = user.Surname,
				Username = user.Username,
				Email = user.Email,
				ImageUrl = user.ImageUrl,
				Description = user.Description
			};
		}
	}
}
