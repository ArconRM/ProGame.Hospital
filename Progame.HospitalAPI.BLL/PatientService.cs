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
    public class PatientService: IPatientService
    {
        private readonly IPatientDAO _patientDAO;

        public PatientService(IPatientDAO patientDAO)
        {
            _patientDAO = patientDAO;
        }

        public ActionResult<int?> Add(Patient patient)
        {
            var validator = new PatientValidator();
            var validationResult = validator.Validate(patient);

            if (validationResult.IsValid)
            {
                int? id = null;
                try
                {
                    id = _patientDAO.Add(patient);
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

        public ActionResult<bool> Delete(Patient patient)
        {
            var validator = new PatientValidator();
            var validationResult = validator.Validate(patient);

            if (validationResult.IsValid)
            {
                try
                {
                    _patientDAO.Delete(patient);
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

        public IEnumerable<Patient> GetAll()
        {
            return _patientDAO.GetAll();
        }

        public Patient GetById(int id)
        {
            return _patientDAO.GetById(id);
        }

        public ActionResult<bool> Update(Patient patient)
        {
            var validator = new PatientValidator();
            var validationResult = validator.Validate(patient);

            if (validationResult.IsValid)
            {
                try
                {
                    _patientDAO.Update(patient);
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
