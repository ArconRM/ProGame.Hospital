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
    public class DoctorService: IDoctorService
    {
        private readonly IDoctorDAO _doctorDAO;

        public DoctorService(IDoctorDAO DoctorDAO)
        {
            _doctorDAO = DoctorDAO;
        }

        public int Add(Doctor doctor)
        {
            return _doctorDAO.Add(doctor);
        }

        public void Delete(Doctor doctor)
        {
            _doctorDAO.Delete(doctor);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorDAO.GetAll();
        }

        public Doctor GetById(int id)
        {
            return _doctorDAO.GetById(id);
        }

        public void Update(Doctor doctor)
        {
            _doctorDAO.Update(doctor);
        }
    }
}
