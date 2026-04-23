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
	public class GetAppUserByRoleQueryHandler(IAppUserRepository repository) : IRequestHandler<GetAppUserByRoleQuery, List<GetAppUserQueryResult>>
	{
		public async Task<List<GetAppUserQueryResult>> Handle(GetAppUserByRoleQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetAppUsersByRoleAsync(request.RoleName);
			return values.Select(x => new GetAppUserQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Surname = x.Surname,
				Email = x.Email,
				Description = x.Description,
				Username = x.Username,
				RoleName = x.AppRole.Name,
				ImageUrl = x.ImageUrl
			}).ToList();
		}
	}
}
