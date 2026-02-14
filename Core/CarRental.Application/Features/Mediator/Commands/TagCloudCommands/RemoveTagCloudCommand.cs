using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.TagCloudCommands
{
	public class RemoveTagCloudCommand(int id) : IRequest<RemoveTagCloudCommand>
	{
		public int Id { get; set; } = id;
	}
}