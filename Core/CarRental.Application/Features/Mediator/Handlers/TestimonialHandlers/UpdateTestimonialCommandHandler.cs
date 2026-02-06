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
	public class UpdateTestimonialCommandHandler(IRepository<Testimonial> repository) : IRequestHandler<UpdateTestimonialCommand, UpdateTestimonialCommand>
	{
		public async Task<UpdateTestimonialCommand> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Testimonial), request.Id);
			}

			value.Name = request.Name;
			value.Title = request.Title;
			value.Comment = request.Comment;
			value.ImageUrl = request.ImageUrl;

			await repository.UpdateAsync(value);
			return request;
		}
	}
}
