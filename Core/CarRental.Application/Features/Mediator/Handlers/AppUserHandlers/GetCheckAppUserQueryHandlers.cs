using CarRental.Application.Features.Mediator.Queries.AppUserQueries;
using CarRental.Application.Features.Mediator.Results.AppUserResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository) : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = await appUserRepository.GetByFilterAsync(x => x.Username == request.Username && x.Password == request.Password);

			var result = new GetCheckAppUserQueryResult();

			if (values == null)
			{
				result.IsExist = false;
			}
			else
			{
				result.IsExist = true;
				result.Username = values.Username;
				result.Id = values.Id;

				var role = await appRoleRepository.GetByFilterAsync(x => x.Id == values.AppRoleId);
				result.Role = role.Name;
			}
			return result;
		}
	}
}