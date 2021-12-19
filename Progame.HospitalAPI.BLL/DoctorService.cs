using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.BLL.Validation;
using ProGame.HospitalAPI.Common.Entities;
using ProGame.HospitalAPI.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progame.HospitalAPI.BLL
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorDAO _doctorDAO;

        public DoctorService(IDoctorDAO DoctorDAO)
        {
            _doctorDAO = DoctorDAO;
        }

        public async Task<ActionResult<int?>> AddDoctorAsync(Doctor doctor)
        {
            var validator = new DoctorValidator();
            var validationResult = validator.Validate(doctor);

            if (validationResult.IsValid)
            {
                int? id = null;
                try
                {
                    id = await _doctorDAO.AddDoctorAsync(doctor);
                }
                catch (Exception e)
                {
                    return new ActionResult<int?>(null, new List<string>()
                    {
                        e.Message
                    });
                }
                return new ActionResult<int?>(id, new List<string>());
            }
            else
            {
                return new ActionResult<int?>(null, validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }

        public async Task<ActionResult<bool>> DeleteDoctorByIdAsync(int id)
        {
            try
            {
                await _doctorDAO.DeleteDoctorByIdAsync(id);
            }
            catch (Exception e)
            {
                return new ActionResult<bool>(false, new List<string>()
                    {
                        e.Message
                    });
            }
            return new ActionResult<bool>(true, new List<string>());
        }

        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctorsAsync()
        {
            try
            {
                var doctors = await _doctorDAO.GetAllDoctorsAsync();
                return new ActionResult<IEnumerable<Doctor>>(doctors, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<IEnumerable<Doctor>>(null, new List<string>()
                    {
                        e.Message
                    });
            }
        }

        public async Task<ActionResult<Doctor>> GetDoctorByIdAsync(int id)
        {
            try
            {
                var doctor = await _doctorDAO.GetDoctorByIdAsync(id);
                return new ActionResult<Doctor>(doctor, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<Doctor>(null, new List<string>()
                    {
                        e.Message
                    });
            }
        }

        public async Task<ActionResult<bool>> UpdateDoctorAsync(Doctor doctor)
        {
            var validator = new DoctorValidator();
            var validationResult = validator.Validate(doctor);

            if (validationResult.IsValid)
            {
                try
                {
                    await _doctorDAO.UpdateDoctorAsync(doctor);
                }
                catch (Exception e)
                {
                    return new ActionResult<bool>(false, new List<string>()
                    {
                        e.Message
                    });
                }
                return new ActionResult<bool>(true, new List<string>());
            }
            else
            {
                return new ActionResult<bool>(false, validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
        }
    }
}
