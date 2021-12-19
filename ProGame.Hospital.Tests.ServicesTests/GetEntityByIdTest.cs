﻿using System;
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
        public void GetPatientById()
        {
            var patientService = DependenciesResolver.Kernel.GetService<IPatientService>();

            var patient = new Patient()
            {
                FullName = "John",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910"
            };

            var result = patientService.Add(patient);
            var patientDb = patientService.GetById(result.Value ?? 0);
            patientService.Delete(patientDb);

            Assert.IsNotNull(patientDb);
            Assert.AreEqual(result.Value, patientDb.Id);
            Assert.AreEqual(patient.FullName, patientDb.FullName);
            Assert.AreEqual(patient.Email, patientDb.Email);
            Assert.AreEqual(patient.PhoneNumber, patientDb.PhoneNumber);
            Assert.Pass();
        }



        [Test]
        public void GetDoctorById()
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
            var doctorDb = doctorService.GetById(result.Value ?? 0);
            doctorService.Delete(doctorDb);

            Assert.IsNotNull(doctorDb);
            Assert.AreEqual(result.Value, doctorDb.Id);
            Assert.AreEqual(doctor.FullName, doctorDb.FullName);
            Assert.AreEqual(doctor.Email, doctorDb.Email);
            Assert.AreEqual(doctor.PhoneNumber, doctorDb.PhoneNumber);
            Assert.AreEqual(doctor.Speciality, doctorDb.Speciality);
            Assert.Pass();
        }

        [Test]
        public void GetRecordById()
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
            var recordDb = recordService.GetById(result.Value ?? 0);
            recordService.Delete(recordDb);

            Assert.IsNotNull(recordDb);
            Assert.AreEqual(result.Value, recordDb.Id);
            Assert.AreEqual(record.Date, recordDb.Date);
            Assert.AreEqual(record.Patient.Id, recordDb.Patient.Id);
            Assert.AreEqual(record.Doctor.Id, recordDb.Doctor.Id);
            Assert.Pass();
        }

    }
}
