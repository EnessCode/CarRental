using CarRental.Application.Features.Mediator.Queries.BlogQueries;
using CarRental.Application.Features.Mediator.Results.BlogResults;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.BlogHandlers
{
	public class GetBlogQueryHandler(IRepository<Blog> blogRepository) : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
	{
		public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
		{
			var values = await blogRepository.GetAllAsync();
			return values.Select(x => new GetBlogQueryResult
			{
				Id = x.Id,
				Title = x.Title,
				Description = x.Description,
				CoverImageUrl = x.CoverImageUrl,
				AuthorId = x.AuthorId,
				CategoryId = x.CategoryId,
				CreatedAt = x.CreatedAt
			}).ToList();
		}
	}
}