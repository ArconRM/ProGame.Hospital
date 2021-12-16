﻿using ProGame.HospitalAPI.Common.Entities;
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

        IEnumerable<Record> GetAll();

        IEnumerable<DateTime> GetGapsByDoctorOnDay(Doctor doctor, DateTime date);

        IEnumerable<DateTime> GetGapsByDoctorOnWeek(Doctor doctor, DateTime dateFrom);

        IDictionary<Doctor, IEnumerable<DateTime>> GetGapsBySpecialityOnDay(Specialities speciality, DateTime date);

        IDictionary<Doctor, IEnumerable<DateTime>> GetGapsBySpecialityOnWeek(Specialities speciality, DateTime dateFrom);

        Record GetById(int id);
    }
}
