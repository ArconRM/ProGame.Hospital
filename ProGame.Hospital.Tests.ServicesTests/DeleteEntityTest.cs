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

            var result = patientService.Add(patient);
            patient.Id = result.Value ?? 0;
            patientService.Delete(patient);
            var patientDb = patientService.GetById(result.Value ?? 0);

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


            var result = doctorService.Add(doctor);
            doctor.Id = result.Value ?? 0;
            doctorService.Delete(doctor);
            var doctorDb = doctorService.GetById(result.Value ?? 0);

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

            var result = recordService.Add(record);
            record.Id = result.Value ?? 0;
            recordService.Delete(record);
            var recordDb = recordService.GetById(result.Value ?? 0);

            Assert.IsNull(recordDb);
        }
    }
}

