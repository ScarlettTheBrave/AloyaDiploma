using Aloya.Domain.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Domain.Validators
{
    public class PasswordValidator : AbstractValidator<string>
    {
        public PasswordValidator()
        {
            RuleFor(password => password).NotEmpty()
                .MinimumLength(12).MaximumLength(100)
                .Matches("[0-9]").WithMessage("The password must contain at least one number.")
                .Matches("[A-Z]").WithMessage("The password must contain at least one upper letter.")
                .Matches("[~_@]").WithMessage("The password must contain at one of next symbols: '~', '_', '@'.");
        }
    }
}
