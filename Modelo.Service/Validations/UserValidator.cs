using FluentValidation;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            ModelValidation();
            CpfValidation();
            BirthDateValidation();
            NameValidation();
        }


        private void ModelValidation()
        {
            RuleFor(c => c)
                 .NotNull()
                 .OnAnyFailure(x =>
                 {
                     throw new ArgumentNullException("Can't found the object.");
                 });

        }

        private void CpfValidation()
        {
            RuleFor(c => c.Cpf)
               .NotEmpty().WithMessage("Is necessary to inform the CPF.")
               .NotNull().WithMessage("Is necessary to inform the CPF.");

        }

        private void BirthDateValidation()
        {
            RuleFor(c => c.BirthDate)
                    .NotEmpty().WithMessage("Is necessary to inform the birth date.")
                    .NotNull().WithMessage("Is necessary to inform the birth date.");

        }

        private void NameValidation()
        {

            RuleFor(c => c.Name)
                    .NotEmpty().WithMessage("Is necessary to inform the name.")
                    .NotNull().WithMessage("Is necessary to inform the birth date.");
        }
    }
}
