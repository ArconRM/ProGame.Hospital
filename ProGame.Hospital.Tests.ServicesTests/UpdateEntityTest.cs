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

            var patient = new Patient()
            {
                Id = 2,
                FullName = "Jeck",
                Email = "asdfgh4567jk@gmail.com",
                PhoneNumber = "+32145678901"
            };

            var id = 2;
            var patientDb = patientService.GetById(id);
            patientService.Update(patient);
            patientService.Delete(patient);

            Assert.IsNotNull(patientDb);
            Assert.AreEqual(id, patientDb.Id);
            Assert.AreEqual(patient.FullName, patientDb.FullName);
            Assert.AreEqual(patient.Email, patientDb.Email);
            Assert.AreEqual(patient.PhoneNumber, patientDb.PhoneNumber);
            Assert.Pass();

        }
    }
}
