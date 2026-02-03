using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarRental.Application.Features.Mediator.Results.FooterAddressResults;
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
	public class GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> footerAddressRepository) : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
	{
		public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await footerAddressRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(FooterAddress), request.Id);
			}

			return new GetFooterAddressByIdQueryResult
			{
				Id = value.Id,
				Description = value.Description,
				Address = value.Address,
				Phone = value.Phone,
				Email = value.Email
			};
		}
	}
}
