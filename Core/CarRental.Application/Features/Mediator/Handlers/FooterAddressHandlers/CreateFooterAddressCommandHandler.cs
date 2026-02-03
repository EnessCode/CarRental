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
	public class CreateFooterAddressCommandHandler(IRepository<FooterAddress> footerAddressRepository) : IRequestHandler<CreateFooterAddressCommand, CreateFooterAddressCommand>
	{
		public async Task<CreateFooterAddressCommand> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
		{
			var footerAddress = new FooterAddress
			{
				Description = request.Description,
				Address = request.Address,
				Phone = request.Phone,
				Email = request.Email
			};

			await footerAddressRepository.CreateAsync(footerAddress);

			return request;
		}
	}
}
