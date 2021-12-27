using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProGame.HospitalAPI.API.ViewModels;
using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.Entities;

namespace ProGame.HospitalAPI.API.Controllers
{
	[Route("api/[controller]")]
	public class AppointmentController : BaseController
	{
		private readonly IAppointmentService _appointmentService;

		public AppointmentController(IAppointmentService appointmentService)
		{
			_appointmentService = appointmentService;
		}

		[HttpPut("UpdateAppointment")]
		public async Task<BaseResponse> UpdateAppointmentAsync([FromBody] Appointment appointment)
        {
			return await GetResponseFromResultAsync(() => _appointmentService.UpdateAppointmentAsync(appointment));
        }
	}
}

