using CarRental.Application.Enums;
using CarRental.Application.Features.Mediator.Commands.AppUserCommands;
using CarRental.Application.Interfaces;
using CarRental.Application.Tools;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class CreateAppUserCommandHandler(IRepository<AppUser> repository) : IRequestHandler<CreateAppUserCommand>
	{
		public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
		{
			var existingUser = await repository.GetByFilterAsync(x => x.Username == request.Username);
			if (existingUser != null)
			{
				throw new Exception("Bu kullanıcı adı zaten sistemde kayıtlı.");
			}

			var existingEmail = await repository.GetByFilterAsync(x => x.Email == request.Email);
			if (existingEmail != null)
			{
				throw new Exception("Bu e-posta adresi ile daha önce kayıt olunmuş.");
			}

			await repository.CreateAsync(new AppUser
			{
				Username = request.Username,
				Password = PasswordHashHelper.HashPassword(request.Password),
				AppRoleId = (int)Roles.Member,
				Email = request.Email,
				Name = request.Name,
				Surname = request.Surname,
				ImageUrl = "https://smithii.io/wp-content/uploads/2023/04/MODERATOR.webp",
				Description = "Üye"
			});
		}
	}
}
