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

        void Delete(Doctor doctor);

        ActionResult<bool> Update(Doctor doctor);

        IEnumerable<Doctor> GetAll();

        Doctor GetById(int id);
    }
}
