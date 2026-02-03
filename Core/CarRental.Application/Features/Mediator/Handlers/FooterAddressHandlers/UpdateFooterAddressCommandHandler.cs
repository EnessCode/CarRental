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

namespace CarRental.Application.FooterAddresss.Mediator.Handlers.FooterAddressHandlers
{
	public class UpdateFooterAddressCommandHandler(IRepository<FooterAddress> footerAddressRepository) : IRequestHandler<UpdateFooterAddressCommand, UpdateFooterAddressCommand>
	{
		public async Task<UpdateFooterAddressCommand> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var value = await footerAddressRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(FooterAddress), request.Id);
			}

			value.Description = request.Description;
			value.Address = request.Address;
			value.Phone = request.Phone;
			value.Email = request.Email;

			await footerAddressRepository.UpdateAsync(value);
			return request;
		}
	}
}
