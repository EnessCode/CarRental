using CarRental.Application.Features.Mediator.Queries.CommentQueries;
using CarRental.Application.Features.Mediator.Results.CommentResults;
using CarRental.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.CommentHandlers
{
	public class GetCommentByBlogIdQueryHandler(ICommentRepository repository) : IRequestHandler<GetCommentByBlogIdQuery, List<GetCommentByBlogIdQueryResult>>
	{
		public async Task<List<GetCommentByBlogIdQueryResult>> Handle(GetCommentByBlogIdQuery request, CancellationToken cancellationToken)
		{
			var values = repository.GetCommentsByBlogId(request.Id);
			return values.Select(x => new GetCommentByBlogIdQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				CreatedDate = x.CreatedDate,
			}).ToList();
		}
	}
}
