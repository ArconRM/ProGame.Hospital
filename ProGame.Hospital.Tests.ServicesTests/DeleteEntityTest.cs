using System;
using System.Threading.Tasks;
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
        public async Task DeletePatient()
        {
            var patientService = DependenciesResolver.Kernel.GetService<IPatientService>();

            var patient = new Patient()
            {
                FullName = "John123",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+12345678910"
            };

            var result = await patientService.AddPatientAsync(patient);
            patient.Id = result.Value ?? 0;
            await patientService.DeletePatientByIdAsync(patient.Id);
            var patientDb = await patientService.GetPatientByIdAsync(result.Value ?? 0);

            Assert.IsNull(patientDb);
        }

        [Test]
        public async Task DeleteDoctor()
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
            doctor.Id = result.Value ?? 0;
            await doctorService.DeleteDoctorByIdAsync(doctor.Id);
            var doctorDb = await doctorService.GetDoctorByIdAsync(result.Value ?? 0);

            Assert.IsNull(doctorDb);
        }

        [Test]
        public async Task DeleteRecord()
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
            record.Id = result.Value ?? 0;
            await recordService.DeleteRecordByIdAsync(record.Id);
            var recordDb = await recordService.GetRecordByIdAsync(result.Value ?? 0);

            Assert.IsNull(recordDb);
        }
    }
}

