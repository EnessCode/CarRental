using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.FeatureCommands
{
	public class CreateFeatureCommand : IRequest<CreateFeatureCommand>
	{
		public string Name { get; set; }
	}
}
