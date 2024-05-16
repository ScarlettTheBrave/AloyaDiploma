using Aloya.Domain.Auth;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aloya.Domain.Validators
{
    public class PhoneValidator : AbstractValidator<string>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone).NotEmpty().Length(14)
                .Matches(@"^\+[0-9]{1,13}$").WithMessage("Phone number must start with '+' followed by 13 digits."); ;
        }
    }
}
