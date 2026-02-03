using CarRental.Application.Features.Mediator.Commands.PricingCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.PricingHandlers
{
	public class CreatePricingCommandHandler(IRepository<Pricing> pricingRepository) : IRequestHandler<CreatePricingCommand, CreatePricingCommand>
	{
		public async Task<CreatePricingCommand> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
		{
			var pricing = new Pricing
			{
				Name = request.Name
			};

			await pricingRepository.CreateAsync(pricing);
			return request;
		}
	}
}