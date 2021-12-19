using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL.Interfaces
{
    public interface IDoctorDAO
    {
        Task<int> AddDoctorAsync(Doctor doctor);

        Task DeleteDoctorByIdAsync(int id);

        Task UpdateDoctorAsync(Doctor doctor);

        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();

        Task<Doctor> GetDoctorByIdAsync(int id);
    }
}
