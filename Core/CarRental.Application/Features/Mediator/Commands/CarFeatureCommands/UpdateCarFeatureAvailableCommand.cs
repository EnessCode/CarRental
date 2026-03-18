using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.CarFeatureCommands
{
	public class UpdateCarFeatureAvailableCommand : IRequest<UpdateCarFeatureAvailableCommand>
	{
		public int CarId { get; set; }
		public bool Available { get; set; }
		public int FeatureId { get; set; }
	}
}
