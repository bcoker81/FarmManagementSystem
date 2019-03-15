using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WherePigsFlyFms.Models;

namespace WherePigsFlyFms.Validators
{
    public class AnimalValidator : AbstractValidator<Animals>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(1,20);

            RuleFor(x => x.DateAcquired)
                .NotNull();

            RuleFor(x => x.TagNumber)
                .MaximumLength(15);

            RuleFor(x => x.Gender)
                .NotNull();
        }
    }
}