using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonValidator:AbstractValidator<Person>
    {
        public PersonValidator()
        {

            RuleFor(p => p.PersonName).NotEmpty().WithMessage("Kişi ismi boş bırakılamaz");
            RuleFor(p => p.PersonName).MinimumLength(1).WithMessage("Kişi isminin uzunluğu en az 1 harf olmalıdır.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş borakılamaz");
        }
    }
}
