using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.ReservationCommands
{
	public class UpdateReservationStatusCommand : IRequest
	{
		public int ReservationId { get; set; }
		public string NewStatus { get; set; }
	}
}
