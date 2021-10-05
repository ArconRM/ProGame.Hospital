using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Interfaces
{
    interface IDoctorService
    {
        void Add(Doctor doctor);

        void Delete(Doctor doctor);
        void Update(Doctor doctor);
        void GetAll();
    }
}
