using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.CommentCommands
{
	public class RemoveCommentCommand(int id) : IRequest<RemoveCommentCommand>
	{
		public int Id { get; set; } = id;

	}
}
