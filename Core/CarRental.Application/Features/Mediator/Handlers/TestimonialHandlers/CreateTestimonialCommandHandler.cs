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
	public class CreateTestimonialCommandHandler(IRepository<Testimonial> repository) : IRequestHandler<CreateTestimonialCommand, CreateTestimonialCommand>
	{
		public async Task<CreateTestimonialCommand> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
		{
			var testimonial = new Testimonial
			{
				Name = request.Name,
				Title = request.Title,
				Comment = request.Comment,
				ImageUrl = request.ImageUrl
			};

			await repository.CreateAsync(testimonial);
			return request;
		}
	}
}
