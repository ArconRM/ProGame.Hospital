using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Interfaces
{
    public interface IDoctorService
    {
        Task<ActionResult<int?>> AddDoctorAsync(Doctor doctor);

        Task<ActionResult<bool>> DeleteDoctorByIdAsync(int id);

        Task<ActionResult<bool>> UpdateDoctorAsync(Doctor doctor);

        Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctorsAsync();

        Task<ActionResult<Doctor>> GetDoctorByIdAsync(int id);
    }
}
