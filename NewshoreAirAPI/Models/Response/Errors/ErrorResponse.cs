namespace NewshoreAirAPI.Models.Response.Errors
{
    /// <summary>
    /// ErrorResponse respects the customError model to give a response to a request.
    /// </summary>
    public class ErrorResponse
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
