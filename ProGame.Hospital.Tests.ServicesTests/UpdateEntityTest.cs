using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.DependenciesInjection;
using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.Hospital.Tests.ServicesTests
{
    public  class UpdateEntityTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UpdatePatient()
        {
            var patientService = DependenciesResolver.Kernel.GetService<IPatientService>();

            var patient1 = new Patient()
            {
                FullName = "John",
                Email = "asdfgh4567jk@gmail.com",
                PhoneNumber = "+12345678901"
            };

            var result = patientService.Add(patient1);

            var patient2 = new Patient()
            {
                Id = result.Value ?? 0,
                FullName = "Jeck",
                Email = "asdfgh1234k@gmail.com",
                PhoneNumber = "+32145678901"
            };

            patientService.Update(patient2);
            var patientDb = patientService.GetById(result.Value ?? 0);
            patientService.Delete(patient2);

            Assert.IsNotNull(patientDb);
            Assert.AreEqual(result.Value, patientDb.Id);
            Assert.AreEqual(patient2.FullName, patientDb.FullName);
            Assert.AreEqual(patient2.Email, patientDb.Email);
            Assert.AreEqual(patient2.PhoneNumber, patientDb.PhoneNumber);
            Assert.Pass();

        }

        [Test]
        public void UpdateDoctor()
        {
            var doctorService = DependenciesResolver.Kernel.GetService<IDoctorService>();

            var doctor1 = new Doctor()
            {
                FullName = "John",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910",
                Speciality = Specialities.Dentist
            };


            var result = doctorService.Add(doctor1);

            var doctor2 = new Doctor()
            {
                Id = result.Value ?? 0,
                FullName = "Jeck",
                Email = "asdfgh1234k@gmail.com",
                PhoneNumber = "+32145678901",
                Speciality = Specialities.Oncologist
            };

            doctorService.Update(doctor2);
            var doctorDb = doctorService.GetById(result.Value ?? 0);
            doctorService.Delete(doctor2);

            Assert.IsNotNull(doctorDb);
            Assert.AreEqual(result.Value, doctorDb.Id);
            Assert.AreEqual(doctor2.FullName, doctorDb.FullName);
            Assert.AreEqual(doctor2.Email, doctorDb.Email);
            Assert.AreEqual(doctor2.PhoneNumber, doctorDb.PhoneNumber);
            Assert.AreEqual(doctor2.Speciality, doctorDb.Speciality);
            Assert.Pass();

        }

        [Test]
        public void UpdateAppointment()
        {
            var appointmentService = DependenciesResolver.Kernel.GetService<IAppointmentService>();
            var recordService = DependenciesResolver.Kernel.GetService<IRecordService>();

            var appointment1 = new Appointment()
            {
                Record = new Record()
                {
                    Date = new DateTime(2021, 12, 05),
                    Doctor = new Doctor()
                    {
                        Id = 1,
                        FullName = "John",
                        Email = "asdfghjk@gmail.com",
                        PhoneNumber = "+12345678910",
                        Speciality = Specialities.Dentist
                    },
                    Patient = new Patient()
                    {
                        Id = 1,
                        FullName = "John",
                        Email = "asdfghjk@gmail.com",
                        PhoneNumber = "+12345678910"
                    }
                },
                 Description = "",
                 Status = Status.Appointed
            };


            var result = recordService.Add(appointment1.Record);

            var appointment2 = new Appointment()
            {
                Id = result.Value ?? 0,
                Record = new Record()
                {
                    Date = new DateTime(2021, 12, 05),
                    Doctor = new Doctor()
                    {
                        Id = 1,
                        FullName = "John",
                        Email = "asdfghjk@gmail.com",
                        PhoneNumber = "+12345678910",
                        Speciality = Specialities.Dentist
                    },
                    Patient = new Patient()
                    {
                        Id = 1,
                        FullName = "John",
                        Email = "asdfghjk@gmail.com",
                        PhoneNumber = "+12345678910"
                    }
                },
                Description = "qwertyuio",
                Status = Status.Appointed
            };

            appointmentService.Update(appointment2);
            var appointmentDb = recordService.GetById(result.Value ?? 0).Appointment;
            recordService.Delete(appointment2.Record);

            Assert.IsNotNull(appointmentDb);
            Assert.AreEqual(result.Value, appointmentDb.Id);
            Assert.AreEqual(appointment2.Description, appointmentDb.Description);
            Assert.AreEqual(appointment2.Status, appointmentDb.Status);
            Assert.Pass();

        }
    }
}
