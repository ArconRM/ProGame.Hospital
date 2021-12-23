using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Interfaces
{
    public interface IPatientService
    {
        Task<ActionResult<int?>> AddPatientAsync(Patient patient);

        Task<ActionResult<bool>> DeletePatientByIdAsync(int id);

        Task<ActionResult<bool>> UpdatePatientAsync(Patient patient);

        Task<ActionResult<IEnumerable<Patient>>> GetAllPatientsAsync();

        Task<ActionResult<Patient>> GetPatientByIdAsync(int id);
    }
}
