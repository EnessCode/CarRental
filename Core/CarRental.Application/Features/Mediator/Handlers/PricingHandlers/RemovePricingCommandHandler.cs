using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.PricingCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.PricingHandlers
{
	public class RemovePricingCommandHandler(IRepository<Pricing> pricingRepository) : IRequestHandler<RemovePricingCommand, RemovePricingCommand>
	{
		public async Task<RemovePricingCommand> Handle(RemovePricingCommand request, CancellationToken cancellationToken)
		{
			var value = await pricingRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Pricing), request.Id);
			}

			await pricingRepository.RemoveAsync(value);
			return request;
		}
	}
}