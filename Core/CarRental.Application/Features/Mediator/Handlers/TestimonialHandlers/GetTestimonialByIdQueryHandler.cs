using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.TestimonialQueries;
using CarRental.Application.Features.Mediator.Results.TestimonialResults;
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
	public class GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository) : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
	{
		public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await repository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Testimonial), request.Id);
			}

			return new GetTestimonialByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name,
				Title = value.Title,
				Comment = value.Comment,
				ImageUrl = value.ImageUrl
			};
		}
	}
}
