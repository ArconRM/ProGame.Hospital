﻿using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.BLL.Interfaces
{
    public interface IAppointmentService
    {
        void Add(Appointment appointment);

        void Delete(Appointment appointment);

        void Update(Appointment appointment);

        IEnumerable<Appointment> GetAll();

        Appointment GetById(int id);
    }
}
