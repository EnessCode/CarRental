using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.TestimonialCommands
{
	public class RemoveTestimonialCommand(int id) : IRequest<RemoveTestimonialCommand>
	{
		public int Id { get; set; } = id;
	}
}
