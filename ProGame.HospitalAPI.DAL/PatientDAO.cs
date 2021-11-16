using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL
{
    public class PatientDAO : IPatientDAO
    {
        public void Add(Patient patient)
        {
            using (HospitalAPIContext db = new())
            {
                db.Patients.Add(patient);
                db.SaveChanges();
            }
        }

        public void Delete(Patient patient)
        {
            using (HospitalAPIContext db = new())
            {
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
        }

        public IEnumerable<Patient> GetAll()
        {
            using (HospitalAPIContext db = new())
            {
                return db.Patients.ToList();
            }
        }

        public Patient GetById(int id)
        {
            using (HospitalAPIContext db = new())
            {
                return db.Patients.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        public void Update(Patient patient)
        {
            using (HospitalAPIContext db = new())
            {
                var userToChange = db.Patients.Where(p => p.Id == patient.Id).FirstOrDefault();
                db.Patients.Remove(userToChange);
                db.Patients.Add(patient);
                db.SaveChanges();
            }
        }
    }
}
