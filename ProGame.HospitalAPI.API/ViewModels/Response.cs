using System.Collections.Generic;

namespace ProGame.HospitalAPI.API.ViewModels
{
    public class Response<TData>: BaseResponse
    {
        public TData Data { get; set; }
        public Response() { }

        public Response(TData data) 
        {
            Data = data;
        }

        public Response(bool success = true, IEnumerable<string> errorMessages = null, TData data = default) : base(success, errorMessages) 
        {
            Data = data;
        }

        public static Response<TData> GetErrorResponse(IEnumerable<string> errorMessages = null)
        {
            return new Response<TData>()
            {
                Success = false,
                ErrorMessages = errorMessages
            };
        }
    }
}
