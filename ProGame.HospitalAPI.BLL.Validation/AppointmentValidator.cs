using FluentValidation;
using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Validation
{
    public class AppointmentValidator: AbstractValidator<Appointment>
    {
        public AppointmentValidator()

        {
            RuleFor(a => a.Status).NotEmpty().WithMessage("Status can't be null");

            RuleFor(a => a.Description).Length(1000).WithMessage("Description length must be under 1000");

            RuleFor(a => a.Record).NotEmpty().WithMessage("Record can't be null");
        }
    }
}
