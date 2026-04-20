using CarRental.Application.Dtos;
using CarRental.Application.Features.Mediator.Commands.AppUserCommands;
using CarRental.Application.Features.Mediator.Queries.AppUserQueries;
using CarRental.Application.Interfaces;
using CarRental.Application.Tools;
using CarRental.Domain.Entities;
using MediatR;

namespace CarRental.Application.Features.Mediator.Handlers.AppUserHandlers
{
	public class LoginCommandHandler(
		IMediator mediator,
		JwtTokenGenerator jwtTokenGenerator,
		IRepository<AppUserToken> tokenRepository) : IRequestHandler<LoginCommand, TokenResponseDto>
	{
		public async Task<TokenResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			var userResult = await mediator.Send(new GetCheckAppUserQuery
			{
				Username = request.Username,
				Password = request.Password
			});

			if (userResult.IsExist)
			{
				var tokenDto = jwtTokenGenerator.GenerateToken(userResult);

				await tokenRepository.CreateAsync(new AppUserToken
				{
					Token = tokenDto.Token,
					ExpireDate = tokenDto.ExpireDate,
					AppUserId = tokenDto.AppUserId
				});

				return tokenDto;
			}

			return null;
		}
	}
}