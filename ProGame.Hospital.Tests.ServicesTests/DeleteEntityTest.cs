using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.DependenciesInjection;
using ProGame.HospitalAPI.Common.Entities;

namespace ProGame.Hospital.Tests.ServicesTests
{
    public class DeleteEntityTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DeletePatient()
        {
            var patientService = DependenciesResolver.Kernel.GetService<IPatientService>();

            var patient = new Patient()
            {
                FullName = "John123",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910"
            };

            var result = patientService.AddPatientAsync(patient);
            patient.Id = result.Result.Value ?? 0;
            patientService.DeletePatientByIdAsync(patient.Id);
            var patientDb = patientService.GetPatientByIdAsync(result.Result.Value ?? 0);

            Assert.IsNull(patientDb);
        }

        [Test]
        public void DeleteDoctor()
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
            doctor.Id = result.Result.Value ?? 0;
            doctorService.DeleteDoctorByIdAsync(doctor.Id);
            var doctorDb = doctorService.GetDoctorByIdAsync(result.Result.Value ?? 0);

            Assert.IsNull(doctorDb);
        }

        [Test]
        public void DeleteRecord()
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
            record.Id = result.Result.Value ?? 0;
            recordService.DeleteRecordByIdAsync(record.Id);
            var recordDb = recordService.GetRecordByIdAsync(result.Result.Value ?? 0);

            Assert.IsNull(recordDb);
        }
    }
}

