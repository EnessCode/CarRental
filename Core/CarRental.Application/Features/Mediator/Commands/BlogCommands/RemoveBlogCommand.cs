using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.BlogCommands
{
	public class RemoveBlogCommand(int id) : IRequest<RemoveBlogCommand>
	{
		public int Id { get; set; } = id;
	}
}