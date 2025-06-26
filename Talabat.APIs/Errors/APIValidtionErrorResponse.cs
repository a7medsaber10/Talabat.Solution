namespace Talabat.APIs.Errors
{
    public class APIValidtionErrorResponse : APIResponse
    {
        public IEnumerable<string> Errors { get; set; }

        public APIValidtionErrorResponse() : base(400)
        {
            Errors = new List<string>();
        }
    }
}
