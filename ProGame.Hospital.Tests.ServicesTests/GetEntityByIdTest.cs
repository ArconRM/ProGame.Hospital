using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.DependenciesInjection;
using ProGame.HospitalAPI.Common.Entities;

namespace ProGame.Hospital.Tests.ServicesTests
{
    public class GetEntityByIdTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetPatientById()
        {
            var patientService = DependenciesResolver.Kernel.GetService<IPatientService>();

            var patient = new Patient()
            {
                FullName = "John",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910"
            };

            var result = await patientService.AddPatientAsync(patient);
            var patientDb = await patientService.GetPatientByIdAsync(result.Value ?? 0);
            await patientService.DeletePatientByIdAsync(patientDb.Value.Id);

            Assert.IsNotNull(patientDb);
            Assert.AreEqual(result.Value, patientDb.Value.Id);
            Assert.AreEqual(patient.FullName, patientDb.Value.FullName);
            Assert.AreEqual(patient.Email, patientDb.Value.Email);
            Assert.AreEqual(patient.PhoneNumber, patientDb.Value.PhoneNumber);
            Assert.Pass();
        }



        [Test]
        public async Task GetDoctorById()
        {
            var doctorService = DependenciesResolver.Kernel.GetService<IDoctorService>();

            var doctor = new Doctor()
            {
                FullName = "John",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910",
                Speciality = Specialities.Dentist
            };

            var result = await doctorService.AddDoctorAsync(doctor);
            var doctorDb = await doctorService.GetDoctorByIdAsync(result.Value ?? 0);
            await doctorService.DeleteDoctorByIdAsync(doctorDb.Value.Id);

            Assert.IsNotNull(doctorDb);
            Assert.AreEqual(result.Value, doctorDb.Value.Id);
            Assert.AreEqual(doctor.FullName, doctorDb.Value.FullName);
            Assert.AreEqual(doctor.Email, doctorDb.Value.Email);
            Assert.AreEqual(doctor.PhoneNumber, doctorDb.Value.PhoneNumber);
            Assert.AreEqual(doctor.Speciality, doctorDb.Value.Speciality);
            Assert.Pass();
        }

        [Test]
        public async Task GetRecordById()
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

            var result = await recordService.AddRecordAsync(record);
            var recordDb = await recordService.GetRecordByIdAsync(result.Value ?? 0);
            await recordService.DeleteRecordByIdAsync(recordDb.Value.Id);

            Assert.IsNotNull(recordDb);
            Assert.AreEqual(result.Value, recordDb.Value.Id);
            Assert.AreEqual(record.Date, recordDb.Value.Date);
            Assert.AreEqual(record.Patient.Id, recordDb.Value.Patient.Id);
            Assert.AreEqual(record.Doctor.Id, recordDb.Value.Doctor.Id);
            Assert.Pass();
        }

    }
}
