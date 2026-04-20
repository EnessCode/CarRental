using CarRental.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.AppUserCommands
{
	public class LoginCommand : IRequest<TokenResponseDto>
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
