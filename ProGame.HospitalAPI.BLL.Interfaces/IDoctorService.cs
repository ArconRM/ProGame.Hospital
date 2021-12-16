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
        ActionResult<int?> Add(Doctor doctor);

        ActionResult<bool> Delete(Doctor doctor);

        ActionResult<bool> Update(Doctor doctor);

        IEnumerable<Doctor> GetAll();

        ActionResult<Doctor> GetById(int id);
    }
}
