using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL
{
    public class DoctorDAO : IDoctorDAO
    {
        public void Add(Doctor doctor)
        {
            using (HospitalAPIContext db = new())
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
            }
        }

        public void Delete(Doctor doctor)
        {
            using (HospitalAPIContext db = new())
            {
                db.Doctors.Remove(doctor);
                db.SaveChanges();
            }
        }

        public IEnumerable<Doctor> GetAll()
        {
            using (HospitalAPIContext db = new())
            {
                return db.Doctors.ToList();
            }
        }

        public Doctor GetById(int id)
        {
            using (HospitalAPIContext db = new())
            {
                return db.Doctors.Where(d => d.Id == id).FirstOrDefault();
            }
        }

        public void Update(Doctor doctor)
        {
            using (HospitalAPIContext db = new())
            {
                var userToChange = db.Doctors.Where(d => d.Id == doctor.Id).FirstOrDefault();
                db.Doctors.Remove(userToChange);
                db.Doctors.Add(doctor);
                db.SaveChanges();
            }
        }
    }
}
