using CarRental.Application.Features.Mediator.Commands.AppUserCommands;
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
	public class ChangeUserRoleCommandHandler(IRepository<AppUser> repository) : IRequestHandler<ChangeUserRoleCommand>
	{
		public async Task Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
		{
			var user = await repository.GetByIdAsync(request.AppUserId);
			if (user != null)
			{
				user.AppRoleId = request.NewRoleId;
				await repository.UpdateAsync(user);
			}
		}
	}
}
