using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.TagCloudCommands
{
	public class CreateTagCloudCommand : IRequest<CreateTagCloudCommand>
	{
		public string Title { get; set; }
		public int BlogId { get; set; }
	}
}