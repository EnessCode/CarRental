using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.FeatureCommands
{
	public class UpdateFeatureCommand : IRequest<UpdateFeatureCommand>
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
