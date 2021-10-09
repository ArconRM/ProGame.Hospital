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
            var filledGaps = _recordDAO.GetAll().Where(r => r.Date.Date == date.Date && r.Doctor.Id == doctor.Id);
            var allGaps = new List<DateTime>();
            for (int i = 9; i < 21; i++)
            {
                allGaps[i] = filledGaps.Where(hour => hour.Date.Hour != i).FirstOrDefault().; //no хранить часы
            }
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
