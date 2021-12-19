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

        public ActionResult<int?> Add(Record record)
        {
            var validator = new RecordValidator();
            var validationResult = validator.Validate(record);

            if (validationResult.IsValid)
            {
                int? id = null;
                try
                {
                    id = _recordDAO.Add(record);
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

        public void Delete(Record record)
        {
            _recordDAO.Delete(record);
        }

        public IEnumerable<Record> GetAll()
        {
            return _recordDAO.GetAll();
        }

        public Record GetById(int id)
        {
            return _recordDAO.GetById(id);
        }

        public IEnumerable<DateTime> GetGapsByDoctorOnDay(Doctor doctor, DateTime date)
        {
            var records = _recordDAO.GetAll().Where(r => r.Date.Date == date.Date && r.Doctor.Id == doctor.Id);
            var gaps = new List<DateTime>();
            bool isFilled;
            
            for (int i = 9; i < 21; i++)
            {
                DateTime newDate = new DateTime(date.Year,date.Month,date.Day);

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

        public IEnumerable<DateTime> GetGapsByDoctorOnWeek(Doctor doctor, DateTime dateFrom)
        {
            var gaps = new List<DateTime>();
            bool isFilled;
            DateTime date = new(dateFrom.Year, dateFrom.Month, dateFrom.Day);

            for (int b = 0; b < 7; b++)
            {
                var records = _recordDAO.GetAll().Where(r => r.Date.Date == date.Date && r.Doctor.Id == doctor.Id).ToList();

                for (int i = 9; i < 21; i++)
                {
                    DateTime newDate = new DateTime(date.Year, date.Month, date.Day);

                    isFilled = false;

                    for (int a = 0; a < records.Count() - 1; a++)
                    {
                        if (records[a].Date.Hour == i)
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
                date.AddDays(1);
            }
            return gaps;
        }

        public IDictionary<Doctor, IEnumerable<DateTime>> GetGapsBySpecialityOnDay(Specialities speciality, DateTime date)
        {
            var recordDict = new Dictionary<Doctor, IEnumerable<DateTime>>();
            var doctors = _doctorDAO.GetAll().Where(d => d.Speciality == speciality).ToList();

            foreach (var doctor in doctors)
            {
                recordDict.Add(doctor, GetGapsByDoctorOnDay(doctor, date));
            }
            return recordDict;
        }

        public IDictionary<Doctor, IEnumerable<DateTime>> GetGapsBySpecialityOnWeek(Specialities speciality, DateTime dateFrom)
        {
            var recordDict = new Dictionary<Doctor, IEnumerable<DateTime>>();
            var doctors = _doctorDAO.GetAll().Where(d => d.Speciality == speciality).ToList();

            foreach (var doctor in doctors)
            {
                recordDict.Add(doctor, GetGapsByDoctorOnWeek(doctor, dateFrom));
            }
            return recordDict;
        }
    }
}
