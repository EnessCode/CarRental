using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.AppUserCommands
{
	public class ChangeUserRoleCommand : IRequest
	{
		public int AppUserId { get; set; }
		public int NewRoleId { get; set; } 
	}
}
