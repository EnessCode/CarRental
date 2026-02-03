using CarRental.Application.Common;
using CarRental.Application.Features.Mediator.Commands.PricingCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.PricingHandlers
{
	public class UpdatePricingCommandHandler(IRepository<Pricing> pricingRepository) : IRequestHandler<UpdatePricingCommand, UpdatePricingCommand>
	{
		public async Task<UpdatePricingCommand> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
		{
			var value = await pricingRepository.GetByIdAsync(request.Id);

			if (value == null)
			{
				throw new NotFoundException(nameof(Pricing), request.Id);
			}

			value.Name = request.Name;

			await pricingRepository.UpdateAsync(value);
			return request;
		}
	}
}