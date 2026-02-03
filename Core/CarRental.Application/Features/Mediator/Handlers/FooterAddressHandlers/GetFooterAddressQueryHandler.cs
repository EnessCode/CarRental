using CarRental.Application.Features.Mediator.Queries.FeatureQueries;
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
	public class GetFooterAddressQueryHandler(IRepository<FooterAddress> footerAddressRepository) : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
	{
		public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
		{
			var values = await footerAddressRepository.GetAllAsync();
			return values.Select(x => new GetFooterAddressQueryResult
			{
				Id = x.Id,
				Description = x.Description,
				Address = x.Address,
				Phone = x.Phone,
				Email = x.Email
			}).ToList();
		}
	}
}
