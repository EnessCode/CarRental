using CarRental.Application.Features.Mediator.Queries.AuthorQueries;
using CarRental.Application.Features.Mediator.Results.AuthorResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.AuthorHandlers
{
	public class GetAuthorQueryHandler(IRepository<Author> authorRepository) : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
	{
		public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = await authorRepository.GetAllAsync();
			return values.Select(x => new GetAuthorQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				ImageUrl = x.ImageUrl,
				Description = x.Description
			}).ToList();
		}
	}
}