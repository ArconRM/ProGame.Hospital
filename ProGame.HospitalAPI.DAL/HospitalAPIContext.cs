using Microsoft.EntityFrameworkCore;
using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace ProGame.HospitalAPI.DAL
{
    public class HospitalAPIContext: DbContext
    {
        public HospitalAPIContext() : base()
        {

        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Record> Records { get; set; }
    }
}
