using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.TagCloudCommands
{
	public class UpdateTagCloudCommand : IRequest<UpdateTagCloudCommand>
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int BlogId { get; set; }
	}
}