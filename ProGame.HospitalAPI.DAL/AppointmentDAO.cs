using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL
{
    public class AppointmentDAO : IAppointmentDAO
    {
        public void Add(Appointment appointment)
        {
            using (HospitalAPIContext db = new())
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
            }
        }

        public void Delete(Appointment appointment)
        {
            using (HospitalAPIContext db = new())
            {
                db.Appointments.Remove(appointment);
                db.SaveChanges();
            }
        }

        public IEnumerable<Appointment> GetAll()
        {
            using (HospitalAPIContext db = new())
            {
                return db.Appointments.ToList();
            }
        }

        public Appointment GetById(int id)
        {
            using (HospitalAPIContext db = new())
            {
                return db.Appointments.Where(a => a.Id == id).FirstOrDefault();
            }
        }

        public void Update(Appointment appointment)
        {
            using (HospitalAPIContext db = new())
            {
                var userToChange = db.Appointments.Where(a => a.Id == appointment.Id).FirstOrDefault();
                db.Appointments.Remove(userToChange);
                db.Appointments.Add(appointment);
                db.SaveChanges();
            }
        }
    }
}
