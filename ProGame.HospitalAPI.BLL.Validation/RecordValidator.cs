using FluentValidation;
using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Validation
{
    public class RecordValidator: AbstractValidator<Record>
    {
        public RecordValidator()
        {
            RuleFor(r => r.Patient).NotEmpty().WithMessage("Patient can't be null");

            RuleFor(r => r.Doctor).NotEmpty().WithMessage("Doctor can't be null");

            RuleFor(r => r.Date).NotEmpty().WithMessage("Date can't be null");

        }
    }
}
