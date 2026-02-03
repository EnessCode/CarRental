using CarRental.Application.Features.Mediator.Results.SocialMediaResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Queries.SocialMediaQueries
{
	public class GetSocialMediaByIdQuery(int id) : IRequest<GetSocialMediaByIdQueryResult>
	{
		public int Id { get; set; } = id;
	}
}