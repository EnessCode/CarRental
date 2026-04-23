using CarRental.Application.Features.Mediator.Queries.AppUserQueries;
using CarRental.Application.Features.Mediator.Results.AppUserResults;
using CarRental.Application.Interfaces.AppUserInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class GetAppUserQueryHandler(IAppUserRepository repository) : IRequestHandler<GetAppUserQuery, List<GetAppUserQueryResult>>
	{
		public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetAppUsersWithRolesAsync();

			return values.Select(x => new GetAppUserQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Surname = x.Surname,
				Email = x.Email,
				Username = x.Username,
				RoleName = x.AppRole?.Name ?? "Rol Atanmamış",
				ImageUrl = x.ImageUrl,
				Description = x.Description
			}).ToList();
		}
	}
}