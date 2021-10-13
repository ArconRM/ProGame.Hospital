using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.HospitalAPI.BLL
{
    public class RecordService: IRecordService
    {
        private readonly IRecordDAO _recordDAO;

        public RecordService(IRecordDAO recordDAO)
        {
            _recordDAO = recordDAO;
        }

        public void Add(Record record)
        {
            _recordDAO.Add(record);
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
            DateTime newDate = new();
            int index = 0;
            //Record record = new();
            //record.Doctor = doctor;

            newDate.AddDays(date.Day);

            for (int i = 9; i < 21; i++)
            {
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
                    gaps[index] = newDate;
                    index++;
                }
                //gaps[i] = records.Where(hour => hour.Date.Hour != i).FirstOrDefault() != null; 
            }
            return gaps;
        }

        public IEnumerable<DateTime> GetGapsByDoctorOnWeek(Doctor doctor, DateTime dateFrom)
        {
            throw new NotImplementedException();
        }

        public IDictionary<Doctor, IEnumerable<DateTime>> GetGapsBySpecialityOnDay(Specialities speciality, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IDictionary<Doctor, IEnumerable<DateTime>> GetGapsBySpecialityOnWeek(Specialities speciality, DateTime dateFrom)
        {
            throw new NotImplementedException();
        }
    }
}
