using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Application.Features.Mediator.Commands.AppUserCommands;
using FluentValidation;

namespace CarRental.Application.Validators.AppUserValidators
{
	public class CreateAppUserValidator : AbstractValidator<CreateAppUserCommand>
	{
		public CreateAppUserValidator()
		{
			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Kullanıcı adı boş geçilemez.")
				.MinimumLength(3).WithMessage("Kullanıcı adı en az 3 karakter olmalıdır.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("E-posta adresi boş geçilemez.")
				.EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
			RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Şifre boş geçilemez.")
				.MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.")
				.Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
				.Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
				.Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");
		}
	}
}