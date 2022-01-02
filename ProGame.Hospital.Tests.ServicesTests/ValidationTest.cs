using NUnit.Framework;
using ProGame.HospitalAPI.BLL.Validation;
using ProGame.HospitalAPI.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProGame.Hospital.Tests.ServicesTests
{
    public class ValidationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDoctorValidationTest()
        {
            var doctor = new Doctor()
            {
                FullName = "John",
                Email = "asdfghjk@gmail.com",
                PhoneNumber = "+000000000000000000000000",
                Speciality = Specialities.Dentist
            };
            var validator = new DoctorValidator();
            var validationResult = validator.Validate(doctor);

            Assert.False(validationResult.IsValid);
        }
    }
}
