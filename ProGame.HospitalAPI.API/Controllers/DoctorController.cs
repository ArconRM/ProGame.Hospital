using Microsoft.AspNetCore.Mvc;
using ProGame.HospitalAPI.API.ViewModels;
using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProGame.HospitalAPI.API.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : BaseController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("GetDoctorById/{id}")]
        public async Task<Response<Doctor>> GetDoctorByIdAsync(int id)
        {
            return await GetResponseFromResultAsync(() => _doctorService.GetDoctorByIdAsync(id));
        }

        [HttpGet("GetDoctors")]
        public async Task<Response<IEnumerable<Doctor>>> GetAllDoctorsAsync()
        {
            return await GetResponseFromResultAsync(() => _doctorService.GetAllDoctorsAsync());
        }

        [HttpPost("AddDoctor")]
        public async Task<BaseResponse> AddDoctorAsync([FromBody] Doctor doctor)
        {
            return await GetResponseFromResultAsync(() => _doctorService.AddDoctorAsync(doctor));
        }

        [HttpPut("UpdateDoctor")]
        public async Task<BaseResponse> UpdateDoctorAsync([FromBody] Doctor doctor)
        {
            return await GetResponseFromResultAsync(() => _doctorService.UpdateDoctorAsync(doctor));
        }

        [HttpDelete("DeleteDoctorById/{id}")]
        public async Task<BaseResponse> DeleteDoctorByIdAsync(int id)
        {
            return await GetResponseFromResultAsync(() => _doctorService.DeleteDoctorByIdAsync(id));
        }
    }
}
