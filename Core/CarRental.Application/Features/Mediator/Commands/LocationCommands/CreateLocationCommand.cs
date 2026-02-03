using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.LocationCommands
{
	public class CreateLocationCommand : IRequest<CreateLocationCommand>
	{
		public string Name { get; set; }
	}
}
