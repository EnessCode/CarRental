using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.BlogCommands
{
	public class CreateBlogCommand : IRequest<CreateBlogCommand>
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string CoverImageUrl { get; set; }
		public int AuthorId { get; set; }
		public int CategoryId { get; set; }
	}
}