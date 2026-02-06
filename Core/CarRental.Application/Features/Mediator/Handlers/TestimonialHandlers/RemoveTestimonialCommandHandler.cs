using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.TestimonialCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.TestimonialHandlers
{
	public class RemoveTestimonialCommandHandler(IRepository<Testimonial> repository) : IRequestHandler<RemoveTestimonialCommand, RemoveTestimonialCommand>
	{
		public async Task<RemoveTestimonialCommand> Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Testimonial), request.Id);
			}

			await repository.RemoveAsync(value);
			return request;
		}
	}
}
