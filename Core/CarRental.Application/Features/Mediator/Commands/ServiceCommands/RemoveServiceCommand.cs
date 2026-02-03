using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.ServiceCommands
{
	public class RemoveServiceCommand(int id) : IRequest<RemoveServiceCommand>
	{
		public int Id { get; set; } = id;
	}
}