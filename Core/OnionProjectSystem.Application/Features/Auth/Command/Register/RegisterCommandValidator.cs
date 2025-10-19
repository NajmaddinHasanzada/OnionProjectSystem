using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProjectSystem.Application.Features.Auth.Command.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.FullName)
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(3)
                .WithName("Name Surname");

            RuleFor(r => r.Email)
                .NotEmpty() 
                .EmailAddress()
                .MaximumLength(60)
                .MinimumLength(8)
                .WithName("Email Address");

            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20)
                .WithName("Password");

            RuleFor(r => r.ConfirmPassword)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(20)
                .Equal(r => r.Password)
                .WithName("Confirm Password");


        }
    }
}
