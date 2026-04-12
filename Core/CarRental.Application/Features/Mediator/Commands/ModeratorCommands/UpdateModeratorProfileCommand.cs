using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.ModeratorCommands
{
	public class UpdateModeratorProfileCommand : IRequest
	{
		public int AppUserId { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }
	}
}