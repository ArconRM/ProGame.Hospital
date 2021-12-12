﻿using System;
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

            var id = patientService.Add(patient);
            patient.Id = id;
            patientService.Delete(patient);
            var patientDb = patientService.GetById(id);

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


            var id = doctorService.Add(doctor);
            doctor.Id = id; 
            doctorService.Delete(doctor);
            var doctorDb = doctorService.GetById(id);

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

            var id = recordService.Add(record);
            record.Id = id;
            recordService.Delete(record);
            var recordDb = recordService.GetById(id);

            Assert.IsNull(recordDb);
        }
    }
}

