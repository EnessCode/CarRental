using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.PricingCommands
{
	public class RemovePricingCommand(int id) : IRequest<RemovePricingCommand>
	{
		public int Id { get; set; } = id;
	}
}