using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.BlogQueries;
using CarRental.Application.Features.Mediator.Results.BlogResults;
using CarRental.Application.Interfaces;
using CarRental.Application.Interfaces.BlogInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogByIdQueryHandler(IRepository<Blog> blogRepository) : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
	{
		public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await blogRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Blog), request.Id);
			}

			return new GetBlogByIdQueryResult
			{
				Id = value.Id,
				Title = value.Title,
				Description = value.Description,
				CoverImageUrl = value.CoverImageUrl,
				CreatedAt = value.CreatedAt,
				AuthorId = value.AuthorId,
				CategoryId = value.CategoryId,
			};
		}
	}
}