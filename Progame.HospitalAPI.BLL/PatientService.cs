using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.HospitalAPI.BLL
{
    public class PatientService: IPatientService
    {
        private readonly IPatientDAO _patientDAO;

        public PatientService(IPatientDAO patientDAO)
        {
            _patientDAO = patientDAO;
        }

        public void Add(Patient patient)
        {
            _patientDAO.Add(patient);
        }

        public void Delete(Patient patient)
        {
            _patientDAO.Delete(patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientDAO.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientDAO.GetById(id);
        }

        public void Update(Patient patient)
        {
            _patientDAO.Update(patient);
        }
    }
}
