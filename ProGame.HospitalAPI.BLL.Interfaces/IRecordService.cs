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
        Task<ActionResult<int?>> AddRecordAsync(Record record);

        Task<ActionResult<bool>> DeleteRecordByIdAsync(int id);

        Task<ActionResult<IEnumerable<Record>>> GetAllRecordsAsync();

        Task<ActionResult<IEnumerable<DateTime>>> GetGapsByDoctorOnDayAsync(Doctor doctor, DateTime date);

        Task<ActionResult<IEnumerable<DateTime>>> GetGapsByDoctorOnWeekAsync(Doctor doctor, DateTime dateFrom);

        Task<ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>> GetGapsBySpecialityOnDayAsync(Specialities speciality, DateTime date);

        Task<ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>> GetGapsBySpecialityOnWeekAsync(Specialities speciality, DateTime dateFrom);

        Task<ActionResult<Record>> GetRecordByIdAsync(int id);
    }
}
