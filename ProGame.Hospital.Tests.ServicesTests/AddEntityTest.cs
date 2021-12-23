using NUnit.Framework;
using ProGame.HospitalAPI.Common.DependenciesInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progame.HospitalAPI.BLL;
using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.BLL.Interfaces;

namespace ProGame.Hospital.Tests.ServicesTests
{
    public class AddEntityTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddPatient()
        {
            var patientService = DependenciesResolver.Kernel.GetService<IPatientService>();

            var patient = new Patient()
            {
                FullName = "John",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910"
            };

            var result = patientService.AddPatientAsync(patient);
            var patientDb = patientService.GetPatientByIdAsync(result.Result.Value ?? 0);
            patientService.DeletePatientByIdAsync(patientDb.Id);

            Assert.IsNotNull(patientDb);
            Assert.AreEqual(result.Result.Value, patientDb.Id);
            Assert.AreEqual(patient.FullName, patientDb.Result.Value.FullName);
            Assert.AreEqual(patient.Email, patientDb.Result.Value.Email);
            Assert.AreEqual(patient.PhoneNumber, patientDb.Result.Value.PhoneNumber);
            Assert.Pass();
        }



        [Test]
        public void AddDoctor()
        {
            var doctorService = DependenciesResolver.Kernel.GetService<IDoctorService>();

            var doctor = new Doctor()
            {
                FullName = "John",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910",
                Speciality = Specialities.Dentist
            };

            var result = doctorService.AddDoctorAsync(doctor);
            var doctorDb = doctorService.GetDoctorByIdAsync(result.Result.Value ?? 0);
            doctorService.DeleteDoctorByIdAsync(doctorDb.Id);

            Assert.IsNotNull(doctorDb);
            Assert.AreEqual(result.Result.Value, doctorDb.Id);
            Assert.AreEqual(doctor.FullName, doctorDb.Result.Value.FullName);
            Assert.AreEqual(doctor.Email, doctorDb.Result.Value.Email);
            Assert.AreEqual(doctor.PhoneNumber, doctorDb.Result.Value.PhoneNumber);
            Assert.AreEqual(doctor.Speciality, doctorDb.Result.Value.Speciality);
            Assert.Pass();
        }

        [Test]
        public void AddRecord()
        {
            var recordService = DependenciesResolver.Kernel.GetService<IRecordService>();

            var record = new Record()
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
            };

            var result = recordService.AddRecordAsync(record);
            var recordDb = recordService.GetRecordByIdAsync(result.Result.Value ?? 0);
            recordService.DeleteRecordByIdAsync(recordDb.Id);

            Assert.IsNotNull(recordDb);
            Assert.AreEqual(result.Result.Value, recordDb.Id);
            Assert.AreEqual(record.Patient.Id, recordDb.Result.Value.Patient.Id);
            Assert.AreEqual(record.Doctor.Id, recordDb.Result.Value.Doctor.Id);
            Assert.AreEqual(record.Date, recordDb.Result.Value.Date);
            Assert.Pass();
        }

    }
}
