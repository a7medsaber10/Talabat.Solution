namespace Talabat.APIs.Errors
{
    public class APIExceptionResponse :APIResponse
    {
        public string? Details { get; set; }

        public APIExceptionResponse(int statusCode, string? message = null, string? details = null) : base(statusCode, message)
        {
            Details = details;
        }
    }
}
