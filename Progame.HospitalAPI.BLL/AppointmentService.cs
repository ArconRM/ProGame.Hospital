using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.BLL.Validation;
using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progame.HospitalAPI.BLL
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentDAO _appointmentDAO;

        public AppointmentService(IAppointmentDAO appointmentDAO)
        {
            _appointmentDAO = appointmentDAO;
        }

        public async Task<ActionResult<bool>> Update(Appointment appointment)
        {
            var validator = new AppointmentValidator();
            var validationResult = validator.Validate(appointment);

            if (validationResult.IsValid)
            {
                try
                {
                    await _appointmentDAO.UpdateAppointmentAsync(appointment);
                } 
                catch(Exception e)
                {
                    return new ActionResult<bool>(false, new List<string>()
                    {
                        e.Message
                    });
                }
                return new ActionResult<bool>(true, new List<string>());
            } 
            else
            {
                return new ActionResult<bool>(false, validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }
    }
}
