using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator :AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MaximumLength(20);
            RuleFor(u => u.LastName).MaximumLength(20);
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).Length(1, 8);
            RuleFor(u => u.Password).Equal(u => u.RePassword);
        }
    }
}
