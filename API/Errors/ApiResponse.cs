namespace API.Errors
{
  public class ApiResponse
  {
    public ApiResponse(int statusCode, string message = null)
    {
      StatusCode = statusCode;
      Message = message ?? StatusCodeMessage(statusCode);
    }
    public int StatusCode { get; set; }
    public string Message { get; set; }

    private string StatusCodeMessage(int statusCode)
    {
      return statusCode switch
      {
        400 => "Bad Request",
        401 => "Unauthorized",
        404 => "Not Found",
        500 => "Internal Server Error, Contact Administrator",
        _ => null
      };
    }
  }
}