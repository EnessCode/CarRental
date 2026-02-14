using CarRental.Application.Common;
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
	public class GetAuthorByIdQueryHandler(IRepository<Author> authorRepository) : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
	{
		public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await authorRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Author), request.Id);
			}

			return new GetAuthorByIdQueryResult
			{
				Id = value.Id,
				Name = value.Name,
				ImageUrl = value.ImageUrl,
				Description = value.Description
			};
		}
	}
}