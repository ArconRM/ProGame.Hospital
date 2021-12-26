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
        public async Task UpdatePatient()
        {
            var patientService = DependenciesResolver.Kernel.GetService<IPatientService>();

            var patient1 = new Patient()
            {
                FullName = "John",
                Email = "asdfgh4567jk@gmail.com",
                PhoneNumber = "+12345678901"
            };

            var result = await patientService.AddPatientAsync(patient1);

            var patient2 = new Patient()
            {
                Id = result.Value ?? 0,
                FullName = "Jeck",
                Email = "asdfgh1234k@gmail.com",
                PhoneNumber = "+32145678901"
            };

            await patientService.UpdatePatientAsync(patient2);
            var patientDb = await patientService.GetPatientByIdAsync(result.Value ?? 0);
            await patientService.DeletePatientByIdAsync(patient2.Id);

            Assert.IsNotNull(patientDb);
            Assert.AreEqual(result.Value, patientDb.Value.Id);
            Assert.AreEqual(patient2.FullName, patientDb.Value.FullName);
            Assert.AreEqual(patient2.Email, patientDb.Value.Email);
            Assert.AreEqual(patient2.PhoneNumber, patientDb.Value.PhoneNumber);
            Assert.Pass();

        }

        [Test]
        public async Task UpdateDoctor()
        {
            var doctorService = DependenciesResolver.Kernel.GetService<IDoctorService>();

            var doctor1 = new Doctor()
            {
                FullName = "John",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910",
                Speciality = Specialities.Dentist
            };


            var result = await doctorService.AddDoctorAsync(doctor1);

            var doctor2 = new Doctor()
            {
                Id = result.Value ?? 0,
                FullName = "Jeck",
                Email = "asdfgh1234k@gmail.com",
                PhoneNumber = "+32145678901",
                Speciality = Specialities.Oncologist
            };

            await doctorService.UpdateDoctorAsync(doctor2);
            var doctorDb = await doctorService.GetDoctorByIdAsync(result.Value ?? 0);
            await doctorService.DeleteDoctorByIdAsync(doctor2.Id);

            Assert.IsNotNull(doctorDb);
            Assert.AreEqual(result.Value, doctorDb.Value.Id);
            Assert.AreEqual(doctor2.FullName, doctorDb.Value.FullName);
            Assert.AreEqual(doctor2.Email, doctorDb.Value.Email);
            Assert.AreEqual(doctor2.PhoneNumber, doctorDb.Value.PhoneNumber);
            Assert.AreEqual(doctor2.Speciality, doctorDb.Value.Speciality);
            Assert.Pass();

        }

        [Test]
        public async Task UpdateAppointment()
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


            var result = await recordService.AddRecordAsync(appointment1.Record);

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

            await appointmentService.UpdateAppointmentAsync(appointment2);
            var appointmentDb = recordService.GetRecordByIdAsync(result.Value ?? 0).Result.Value.Appointment;
            await recordService.DeleteRecordByIdAsync(appointment2.Record.Id);

            Assert.IsNotNull(appointmentDb);
            Assert.AreEqual(result.Value, appointmentDb.Id);
            Assert.AreEqual(appointment2.Description, appointmentDb.Description);
            Assert.AreEqual(appointment2.Status, appointmentDb.Status);
            Assert.Pass();

        }
    }
}
