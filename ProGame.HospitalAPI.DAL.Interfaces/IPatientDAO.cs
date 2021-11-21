﻿using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.DAL.Interfaces
{
    public interface IPatientDAO
    {
        int Add(Patient patient);

        void Delete(Patient patient);

        void Update(Patient patient);

        IEnumerable<Patient> GetAll();

        Patient GetById(int id);
    }
}
