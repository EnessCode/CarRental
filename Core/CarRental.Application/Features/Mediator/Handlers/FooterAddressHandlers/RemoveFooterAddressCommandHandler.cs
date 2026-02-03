using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
	public class RemoveFooterAddressCommandHandler(IRepository<FooterAddress> footerAddressRepository) : IRequestHandler<RemoveFooterAddressCommand, RemoveFooterAddressCommand>
	{
		public async Task<RemoveFooterAddressCommand> Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var value = await footerAddressRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(FooterAddress), request.Id);
			}

			await footerAddressRepository.RemoveAsync(value);
			return request;
		}
	}
}
