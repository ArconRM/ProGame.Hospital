using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.BLL.Validation;
using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.HospitalAPI.BLL
{
    public class RecordService : IRecordService
    {
        private readonly IRecordDAO _recordDAO;
        private readonly IDoctorDAO _doctorDAO;

        public RecordService(IRecordDAO recordDAO, IDoctorDAO doctorDAO)
        {
            _recordDAO = recordDAO;
            _doctorDAO = doctorDAO;
        }

        public async Task<ActionResult<int?>> AddRecordAsync(Record record)
        {
            var validator = new RecordValidator();
            var validationResult = validator.Validate(record);

            if (validationResult.IsValid)
            {
                int? id = null;
                try
                {
                    id = await _recordDAO.AddRecordAsync(record);
                }
                catch (Exception e)
                {
                    return new ActionResult<int?>(null, new List<string>()
                    {
                        e.Message
                    });
                }
                return new ActionResult<int?>(id, new List<string>());
            }
            else
            {
                return new ActionResult<int?>(null, validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }

        public async Task<ActionResult<bool>> DeleteRecordByIdAsync(int id)
        {
            try
            {
                await _recordDAO.DeleteRecordByIdAsync(id);
            }
            catch (Exception e)
            {
                return new ActionResult<bool>(false, new List<string>()
                    {
                        e.Message
                    });
            }
            return new ActionResult<bool>(true, new List<string>());
        }

        public async Task<ActionResult<IEnumerable<Record>>> GetAllRecordsAsync()
        {
            try
            {
                var records = await _recordDAO.GetAllRecordsAsync();
                return new ActionResult<IEnumerable<Record>>(records, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<IEnumerable<Record>>(null, new List<string>()
                    {
                        e.Message
                    });
            }
        }

        public async Task<ActionResult<Record>> GetRecordByIdAsync(int id)
        {
            try
            {
                var record = await _recordDAO.GetRecordByIdAsync(id);
                return new ActionResult<Record>(record, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<Record>(null, new List<string>()
                    {
                        e.Message
                    });
            }

        }

        public async Task<ActionResult<IEnumerable<DateTime>>> GetGapsByDoctorOnDayAsync(Doctor doctor, DateTime date)
        {
            try
            {
                var records = await _recordDAO.GetAllRecordsAsync();
                var recordsByDoctor = records.Where(r => r.Date.Date == date.Date && r.Doctor.Id == doctor.Id);
                var result = GetGapsByDoctorOnDay(recordsByDoctor, date);

                return new ActionResult<IEnumerable<DateTime>>(result, new List<string>());
            }
            catch(Exception e)
            {
                return new ActionResult<IEnumerable<DateTime>>(null, new List<string>()
                {
                    e.Message
                });
            }
        }

        public async Task<ActionResult<IEnumerable<DateTime>>> GetGapsByDoctorOnWeekAsync(Doctor doctor, DateTime dateFrom)
        {
            try
            {
                DateTime date = new(dateFrom.Year, dateFrom.Month, dateFrom.Day);
                var records = await _recordDAO.GetAllRecordsAsync();
                var result = new List<DateTime>();

                for (int i = 0; i < 7; i++)
                {
                    var recordsByDay = records.Where(r => r.Date.Date == date.Date && r.Doctor.Id == doctor.Id);
                    result = result.Concat(GetGapsByDoctorOnDay(recordsByDay, date)).ToList();
                    date.AddDays(1);
                }
                
                return new ActionResult<IEnumerable<DateTime>>(result, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<IEnumerable<DateTime>>(null, new List<string>()
                {
                    e.Message
                });
            }
        }

        public async Task<ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>> GetGapsBySpecialityOnDayAsync(Specialities speciality, DateTime date)
        {
            try
            {
                var recordDict = new Dictionary<Doctor, IEnumerable<DateTime>>();
                var doctors = await _doctorDAO.GetAllDoctorsAsync();
                var doctorsBySpeciality = doctors.Where(d => d.Speciality == speciality).ToList();

                foreach (var doctor in doctorsBySpeciality)
                {
                    recordDict.Add(doctor, (IEnumerable<DateTime>)GetGapsByDoctorOnDayAsync(doctor, date));
                }
                return new ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>(recordDict, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>(null, new List<string>()
                {
                    e.Message
                });
            }
        }

        public async Task<ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>> GetGapsBySpecialityOnWeekAsync(Specialities speciality, DateTime dateFrom)
        {
            try
            {
                var recordDict = new Dictionary<Doctor, IEnumerable<DateTime>>();
                var doctors = await _doctorDAO.GetAllDoctorsAsync();
                var doctorsBySpeciality = doctors.Where(d => d.Speciality == speciality).ToList();

                foreach (var doctor in doctorsBySpeciality)
                {
                    recordDict.Add(doctor, (IEnumerable<DateTime>)GetGapsByDoctorOnWeekAsync(doctor, dateFrom));
                }
                return new ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>(recordDict, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<IDictionary<Doctor, IEnumerable<DateTime>>>(null, new List<string>()
                {
                    e.Message
                });
            }
        }



        private IEnumerable<DateTime> GetGapsByDoctorOnDay(IEnumerable<Record> records, DateTime date)
        {
            var gaps = new List<DateTime>();
            bool isFilled;

            for (int i = 9; i < 21; i++)
            {
                DateTime newDate = new DateTime(date.Year, date.Month, date.Day);

                isFilled = false;

                for (int a = 0; a < records.Count() - 1; a++)
                {
                    if (records.ToArray()[a].Date.Hour == i)
                    {
                        isFilled = true;
                        break;
                    }
                }

                if (!isFilled)
                {
                    newDate.AddHours(i);
                    gaps.Add(newDate);
                }
            }

            return gaps;
        }

        //private IEnumerable<DateTime> GetGapsByDoctorOnWeek(IEnumerable<Record> records, DateTime date)
        //{
        //    var gaps = new List<DateTime>();
        //    bool isFilled;

        //    for (int b = 0; b < 7; b++)
        //    {
        //        for (int i = 9; i < 21; i++)
        //        {
        //            DateTime newDate = new(date.Year, date.Month, date.Day);

        //            isFilled = false;

        //            for (int a = 0; a < records.Count() - 1; a++)
        //            {
        //                if (records.ToArray()[a].Date.Hour == i)
        //                {
        //                    isFilled = true;
        //                    break;
        //                }
        //            }

        //            if (!isFilled)
        //            {
        //                newDate.AddHours(i);
        //                gaps.Add(newDate);
        //            }
        //        }
        //        date.AddDays(1);
        //    }
        //    return gaps;
        //}
    }
}
