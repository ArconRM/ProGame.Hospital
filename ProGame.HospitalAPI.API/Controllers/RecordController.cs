using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProGame.HospitalAPI.API.ViewModels;
using ProGame.HospitalAPI.BLL.Interfaces;
using ProGame.HospitalAPI.Common.Entities;

namespace ProGame.HospitalAPI.API.Controllers
{
	[Route("api/[controller]")]
	public class RecordController: BaseController
	{
		private readonly IRecordService _recordService;

		public RecordController(IRecordService recordService)
		{
			_recordService = recordService;
		}

		[HttpGet("GetRecordById/{id}")]
		public async Task<Response<Record>> GetRecordByIdAsync(int id)
		{
			return await GetResponseFromResultAsync(() => _recordService.GetRecordByIdAsync(id));
		}

		[HttpGet("GetRecords")]
		public async Task<Response<System.Collections.Generic.IEnumerable<Record>>> GetAllRecordAsync(int id)
		{
			return await GetResponseFromResultAsync(() => _recordService.GetAllRecordsAsync());
		}

		[HttpPost("AddRecord")]
		public async Task<BaseResponse> AddRecordAsync([FromBody] Record record)
		{
			return await GetResponseFromResultAsync(() => _recordService.AddRecordAsync(record));
		}

		[HttpDelete("DeleteRecordById/{id}")]
		public async Task<BaseResponse> DeleteRecordAsync(int id)
		{
			return await GetResponseFromResultAsync(() => _recordService.DeleteRecordByIdAsync(id));
		}
	}
}

