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
    public class PatientService : IPatientService
    {
        private readonly IPatientDAO _patientDAO;

        public PatientService(IPatientDAO patientDAO)
        {
            _patientDAO = patientDAO;
        }

        public async Task<ActionResult<int?>> AddPatientAsync(Patient patient)
        {
            var validator = new PatientValidator();
            var validationResult = validator.Validate(patient);

            if (validationResult.IsValid)
            {
                int? id = null;
                try
                {
                    id = await _patientDAO.AddPatientAsync(patient);
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

        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                await _patientDAO.DeletePatientByIdAsync(id);
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

        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatientsAsync()
        {
            try
            {
                var patients = await _patientDAO.GetAllPatientsAsync();
                return new ActionResult<IEnumerable<Patient>>(patients, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<IEnumerable<Patient>>(null, new List<string>()
                    {
                        e.Message
                    });
            }
        }

        public async Task<ActionResult<Patient>> GetPatientByIdAsync(int id)
        {
            try
            {
                var patient = await _patientDAO.GetPatientByIdAsync(id);
                return new ActionResult<Patient>(patient, new List<string>());
            }
            catch (Exception e)
            {
                return new ActionResult<Patient>(null, new List<string>()
                    {
                        e.Message
                    });
            }
        }

        public async Task<ActionResult<bool>> UpdatePatientAsync(Patient patient)
        {
            try
            {
                await _patientDAO.UpdatePatientAsync(patient);
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
    }
}
