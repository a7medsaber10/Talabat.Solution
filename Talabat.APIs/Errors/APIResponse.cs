using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Talabat.APIs.Errors
{
    public class APIResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public APIResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatuCode(statusCode);
        }

        private string? GetDefaultMessageForStatuCode(int statusCode)
        {
            return StatusCode switch
            {
                400 => "Bad Request",
                404 => "Not Found",
                401 => "UnAuthorized",
                500 => "Server Error",
                _ => null
            };
        } 
    }
}
