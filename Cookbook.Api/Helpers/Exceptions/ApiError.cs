namespace Cookbook.Api.Helpers.Exceptions
{
    public class ApiError
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public string StackTrace { get; set; }
    }
}
