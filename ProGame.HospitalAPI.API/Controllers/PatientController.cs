using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProGame.HospitalAPI.API.ViewModels;
using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.Entities;

namespace ProGame.HospitalAPI.API.Controllers
{
	[Route("api/[controller]")]
	public class PatientController: BaseController
	{
		private readonly IPatientService _patientService;

		public PatientController(IPatientService patientService)
		{
			_patientService = patientService;
		}

		[HttpGet("GetPatientById/{id}")]
		public async Task<Response<Patient>> GetPatientByIdAsync(int id)
        {
			return await GetResponseFromResultAsync(() => _patientService.GetPatientByIdAsync(id));
        }

		[HttpGet("GetPatients")]
		public async Task<Response<IEnumerable<Patient>>> GetAllPatientAsync()
		{
			return await GetResponseFromResultAsync(() => _patientService.GetAllPatientsAsync());
		}

		[HttpPost("AddPatient")]
		public async Task<BaseResponse> AddPatientAsync([FromBody] Patient patient)
        {
			return await GetResponseFromResultAsync(() => _patientService.AddPatientAsync(patient));
        }

		[HttpPut("UpdatePatient")]
		public async Task<BaseResponse> UpdatePatientAsync([FromBody] Patient patient)
		{
			return await GetResponseFromResultAsync(() => _patientService.UpdatePatientAsync(patient));
		}

		[HttpDelete("DeletePatientById/{id}")]
		public async Task<BaseResponse> DeletePatientAsync(int id)
		{
			return await GetResponseFromResultAsync(() => _patientService.DeletePatientByIdAsync(id));
		}
	}
}

