using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.SocialMediaCommands
{
	public class CreateSocialMediaCommand : IRequest<CreateSocialMediaCommand>
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string IconUrl { get; set; }
	}
}