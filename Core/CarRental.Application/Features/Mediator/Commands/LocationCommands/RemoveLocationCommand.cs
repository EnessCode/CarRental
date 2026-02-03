using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.LocationCommands
{
	public class RemoveLocationCommand(int id) : IRequest<RemoveLocationCommand>
	{
		public int Id { get; set; } = id;
	}
}
