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
        ActionResult<int?> Add(Patient patient);

        Task<ActionResult<bool>> Delete(int id);

        ActionResult<bool> Update(Patient patient);

        ActionResult<Task<IEnumerable<Patient>>> GetAll();

        Task<ActionResult<Patient>> GetById(int id);
    }
}
