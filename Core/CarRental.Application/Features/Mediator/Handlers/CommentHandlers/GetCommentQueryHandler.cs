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
	public class GetCommentQueryHandler(ICommentRepository repository) : IRequestHandler<GetCommentQuery, List<GetCommentQueryResult>>
	{
		public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
		{
			var values = await repository.GetAllAsync();
			return values.Select(x => new GetCommentQueryResult
			{
				Id = x.Id,
				Name = x.Name,
				Description = x.Description,
				BlogId = x.BlogId
			}).ToList();
		}
	}
}
