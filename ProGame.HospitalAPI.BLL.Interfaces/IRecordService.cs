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

        ActionResult<bool> Delete(Record record);

        ActionResult<IEnumerable<Record>> GetAll();

        ActionResult<IEnumerable<DateTime>> GetGapsByDoctorOnDay(Doctor doctor, DateTime date);

        ActionResult<IEnumerable<DateTime>> GetGapsByDoctorOnWeek(Doctor doctor, DateTime dateFrom);

        ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>> GetGapsBySpecialityOnDay(Specialities speciality, DateTime date);

        ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>> GetGapsBySpecialityOnWeek(Specialities speciality, DateTime dateFrom);

        ActionResult<Record> GetById(int id);
    }
}
