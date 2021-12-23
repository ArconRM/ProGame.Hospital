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

            var result = patientService.AddPatientAsync(patient1);

            var patient2 = new Patient()
            {
                Id = result.Result.Value ?? 0,
                FullName = "Jeck",
                Email = "asdfgh1234k@gmail.com",
                PhoneNumber = "+32145678901"
            };

            patientService.UpdatePatientAsync(patient2);
            var patientDb = patientService.GetPatientByIdAsync(result.Result.Value ?? 0);
            patientService.DeletePatientByIdAsync(patient2.Id);

            Assert.IsNotNull(patientDb);
            Assert.AreEqual(result.Result.Value, patientDb.Id);
            Assert.AreEqual(patient2.FullName, patientDb.Result.Value.FullName);
            Assert.AreEqual(patient2.Email, patientDb.Result.Value.Email);
            Assert.AreEqual(patient2.PhoneNumber, patientDb.Result.Value.PhoneNumber);
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


            var result = doctorService.AddDoctorAsync(doctor1);

            var doctor2 = new Doctor()
            {
                Id = result.Result.Value ?? 0,
                FullName = "Jeck",
                Email = "asdfgh1234k@gmail.com",
                PhoneNumber = "+32145678901",
                Speciality = Specialities.Oncologist
            };

            doctorService.UpdateDoctorAsync(doctor2);
            var doctorDb = doctorService.GetDoctorByIdAsync(result.Result.Value ?? 0);
            doctorService.DeleteDoctorByIdAsync(doctor2.Id);

            Assert.IsNotNull(doctorDb);
            Assert.AreEqual(result.Result.Value, doctorDb.Id);
            Assert.AreEqual(doctor2.FullName, doctorDb.Result.Value.FullName);
            Assert.AreEqual(doctor2.Email, doctorDb.Result.Value.Email);
            Assert.AreEqual(doctor2.PhoneNumber, doctorDb.Result.Value.PhoneNumber);
            Assert.AreEqual(doctor2.Speciality, doctorDb.Result.Value.Speciality);
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


            var result = recordService.AddRecordAsync(appointment1.Record);

            var appointment2 = new Appointment()
            {
                Id = result.Result.Value ?? 0,
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

            appointmentService.UpdateAppointmentAsync(appointment2);
            var appointmentDb = recordService.GetRecordByIdAsync(result.Result.Value ?? 0).Result.Value.Appointment;
            recordService.DeleteRecordByIdAsync(appointment2.Record.Id);

            Assert.IsNotNull(appointmentDb);
            Assert.AreEqual(result.Result.Value, appointmentDb.Id);
            Assert.AreEqual(appointment2.Description, appointmentDb.Description);
            Assert.AreEqual(appointment2.Status, appointmentDb.Status);
            Assert.Pass();

        }
    }
}
