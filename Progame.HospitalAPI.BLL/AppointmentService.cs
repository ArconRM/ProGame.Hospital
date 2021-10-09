using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System.Collections.Generic;

namespace Progame.HospitalAPI.BLL
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IAppointmentDAO _appointmentDAO;

        public AppointmentService(IAppointmentDAO appointmentDAO)
        {
            _appointmentDAO = appointmentDAO;
        }

        public void Add(Appointment appointment)
        {
            _appointmentDAO.Add(appointment);
        }

        public void Delete(Appointment appointment)
        {
            _appointmentDAO.Delete(appointment);
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentDAO.GetAll();
        }

        public Appointment GetById(int id)
        {
            return _appointmentDAO.GetById(id);
        }

        public void Update(Appointment appointment)
        {
            _appointmentDAO.Update(appointment);
        }
    }
}
