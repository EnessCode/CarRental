using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.SocialMediaCommands
{
	public class RemoveSocialMediaCommand(int id) : IRequest<RemoveSocialMediaCommand>
	{
		public int Id { get; set; } = id;
	}
}