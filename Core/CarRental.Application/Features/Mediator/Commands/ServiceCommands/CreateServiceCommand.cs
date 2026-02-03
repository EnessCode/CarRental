using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.ServiceCommands
{
	public class CreateServiceCommand : IRequest<CreateServiceCommand>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string IconUrl { get; set; }
	}
}