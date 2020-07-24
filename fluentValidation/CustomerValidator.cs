using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mapper_test
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.surname).NotEmpty();
            RuleFor(x => x.lastname).NotEmpty().WithMessage("Please specify a first name");
            RuleFor(x => x.address).Length(20, 30);
            RuleFor(x => x.email).EmailAddress();
            RuleFor(x => x.phone).NotEmpty().Length(10).Custom((phone,context) =>
            {
                var arr = new [] { "5","8" };
                if (!arr.Contains(phone.Substring(0, 1)))
                {
                    context.AddFailure("Phone Number Must Start With 5 Or 8");
                }
            });
            ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");
        }
    }

}
