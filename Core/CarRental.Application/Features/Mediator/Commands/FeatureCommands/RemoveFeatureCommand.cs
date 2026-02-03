using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.FeatureCommands
{
	public class RemoveFeatureCommand(int id) : IRequest<RemoveFeatureCommand>
	{
		public int Id { get; set; } = id;
	}
}
