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

        public ActionResult<int?> Add(Doctor doctor)
        {
            var validator = new DoctorValidator();
            var validationResult = validator.Validate(doctor);

            if (validationResult.IsValid)
            {
                int? id = null;
                try
                {
                    id = _doctorDAO.Add(doctor);
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

        public ActionResult<bool> Delete(Doctor doctor)
        {
            var validator = new DoctorValidator();
            var validationResult = validator.Validate(doctor);

            if (validationResult.IsValid)
            {
                try
                {
                    _doctorDAO.Delete(doctor);
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

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorDAO.GetAll();
        }

        public Doctor GetById(int id)
        {
            var validator = new DoctorValidator();
            int? id = null;
            try
            {
                id = _doctorDAO.Add(doctor);
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

    public ActionResult<bool> Update(Doctor doctor)
    {
        var validator = new DoctorValidator();
        var validationResult = validator.Validate(doctor);

        if (validationResult.IsValid)
        {
            try
            {
                _doctorDAO.Update(doctor);
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
