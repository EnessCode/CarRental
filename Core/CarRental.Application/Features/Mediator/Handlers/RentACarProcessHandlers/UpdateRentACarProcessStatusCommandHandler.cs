using CarRental.Application.Features.Mediator.Commands.RentACarProcessCommands;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Features.Mediator.Handlers.RentACarProcessHandlers
{
	public class UpdateRentACarProcessStatusCommandHandler(IRepository<RentACarProcess> repository) : IRequestHandler<UpdateRentACarProcessStatusCommand>
	{
		public async Task Handle(UpdateRentACarProcessStatusCommand request, CancellationToken cancellationToken)
		{
			var values = await repository.GetByIdAsync(request.Id);

			if (values != null)
			{
				values.Status = request.NewStatus;
				if (request.NewStatus.Equals("Tamamlandı", StringComparison.OrdinalIgnoreCase))
				{
					values.DropOffDescription = "Araç teslim alındı.";
				}

				if (request.NewStatus.Equals("Müşteride", StringComparison.OrdinalIgnoreCase))
				{
					values.PickUpDescription = "Araç müşteriye teslim edildi.";
				}

				await repository.UpdateAsync(values);
			}
		}
	}
}
