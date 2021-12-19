using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL.Interfaces
{
    public interface IAppointmentDAO
    {
        Task UpdateAppointmentAsync(Appointment appointment);
    }
}
