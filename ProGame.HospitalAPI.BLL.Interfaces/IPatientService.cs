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

        void Delete(Patient patient);

        ActionResult<bool> Update(Patient patient);

        IEnumerable<Patient> GetAll();

        Patient GetById(int id);
    }
}
