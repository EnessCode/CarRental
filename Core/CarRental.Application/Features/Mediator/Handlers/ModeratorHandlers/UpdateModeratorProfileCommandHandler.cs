using CarRental.Application.Features.Mediator.Commands.ModeratorCommands;
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
	public class UpdateModeratorProfileCommandHandler(IRepository<AppUser> repository) : IRequestHandler<UpdateModeratorProfileCommand>
	{
		public async Task Handle(UpdateModeratorProfileCommand request, CancellationToken cancellationToken)
		{
			var user = await repository.GetByIdAsync(request.AppUserId);
			if (user != null)
			{
				user.ImageUrl = request.ImageUrl;
				user.Description = request.Description;
				await repository.UpdateAsync(user);
			}
		}
	}
}
