using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL.Interfaces
{
    public interface IPatientDAO
    {
        Task<int> AddPatientAsync(Patient patient);

        Task DeletePatientByIdAsync(int id);

        Task UpdatePatientAsync(Patient patient);

        Task<IEnumerable<Patient>> GetAllPatientsAsync();

        Task<Patient> GetPatientByIdAsync(int id);
    }
}
