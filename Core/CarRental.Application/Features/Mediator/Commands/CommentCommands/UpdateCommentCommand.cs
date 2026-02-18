using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.CommentCommands
{
	public class UpdateCommentCommand : IRequest<UpdateCommentCommand>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public int BlogId { get; set; }
	}
}
