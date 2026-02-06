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
	public class GetTestimonialQueryHandler(IRepository<Testimonial> repository) : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
	{
		public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetAllAsync();
			return values.Select(x => new GetTestimonialQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Title = x.Title,
				Comment = x.Comment,
				ImageUrl = x.ImageUrl
			}).ToList();
		}
	}
}
