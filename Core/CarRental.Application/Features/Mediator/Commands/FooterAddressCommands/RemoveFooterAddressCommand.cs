using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Commands.FooterAddressCommands
{
	public class RemoveFooterAddressCommand(int id) : IRequest<RemoveFooterAddressCommand>
	{
		public int Id { get; set; } = id;
	}
}
