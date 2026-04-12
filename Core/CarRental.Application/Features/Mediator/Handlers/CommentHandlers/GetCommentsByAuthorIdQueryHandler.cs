using CarRental.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRental.Application.Features.Mediator.Results.CommentResults;
using CarRental.Application.Interfaces.BlogInterfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.CommentHandlers
{
	public class GetCommentsByAuthorIdQueryHandler(IBlogRepository repository) : IRequestHandler<GetCommentsByAuthorIdQuery, List<GetCommentsByAuthorIdQueryResult>>
	{
		public async Task<List<GetCommentsByAuthorIdQueryResult>> Handle(GetCommentsByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetAllBlogsWithAuthor();

			if (values == null) return new List<GetCommentsByAuthorIdQueryResult>();

			var authorComments = values
				.Where(x => x.AppUserId == request.Id)
				.SelectMany(x => x.Comments.Select(c => new GetCommentsByAuthorIdQueryResult
				{
					Id = c.Id,
					Name = c.Name,
					Description = c.Description,
					CreatedDate = c.CreatedDate,
					BlogTitle = x.Title
				})).OrderByDescending(x => x.CreatedDate).ToList();

			return authorComments;
		}
	}
}
