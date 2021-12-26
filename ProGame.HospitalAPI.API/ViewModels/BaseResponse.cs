using System.Collections.Generic;

namespace ProGame.HospitalAPI.API.ViewModels
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public IEnumerable<string> ErrorMessages { get; set; }

        public BaseResponse() { }

        public BaseResponse(bool success = true, IEnumerable<string> errorMessages = null)
        {
            Success = success;
            ErrorMessages = errorMessages;
        }

        public static BaseResponse GetErrorBaseResponse(IEnumerable<string> messages = null)
        {
            return new BaseResponse()
            {
                Success = false,
                ErrorMessages = messages
            };
        }
    }
}
