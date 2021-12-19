using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Interfaces
{
    public interface IRecordService
    {
        ActionResult<int?> Add(Record record);

        Task<ActionResult<bool>> Delete(int id);

        Task<ActionResult<IEnumerable<Record>>> GetAll();

        Task<ActionResult<IEnumerable<DateTime>>> GetGapsByDoctorOnDay(Doctor doctor, DateTime date);

        Task<ActionResult<IEnumerable<DateTime>>> GetGapsByDoctorOnWeek(Doctor doctor, DateTime dateFrom);

        Task<ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>> GetGapsBySpecialityOnDay(Specialities speciality, DateTime date);

        Task<ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>> GetGapsBySpecialityOnWeek(Specialities speciality, DateTime dateFrom);

        Task<ActionResult<Record>> GetById(int id);
    }
}
