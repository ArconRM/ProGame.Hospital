using FluentValidation;
using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Validation
{
    public class DoctorValidator: AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(d => d.PhoneNumber).NotEmpty().WithMessage("PhoneNumber can't be null")
                .Length(12).WithMessage("PhoneNumber length must be 12");

            RuleFor(d => d.FullName).NotEmpty().WithMessage("FullName can't be null")
                .Length(200).WithMessage("FullName length must be under 200");

            RuleFor(d => d.Speciality).NotEmpty().WithMessage("Speciality can't be null");

            RuleFor(d => d.Appointments).NotEmpty().WithMessage("Appointments can't be null");

        }
    }
}
