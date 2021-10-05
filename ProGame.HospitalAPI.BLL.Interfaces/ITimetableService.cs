using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Interfaces
{
    public interface ITimetableService
    {
        void Add(Timetable timetable);

        void Delete(Timetable timetable);
        void Update(Timetable timetable);
        void GetAll();
    }
}
