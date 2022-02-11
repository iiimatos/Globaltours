using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/[controller]")]
  public class ErrorTestController : Controller
  {
    private readonly ApplicationDbContext _db;

    public ErrorTestController(ApplicationDbContext db)
    {
      _db = db;
    }

    [HttpGet("notfound")]
    public ActionResult GetNotFoundError()
    {
      var something = _db.Places.Find(1660);
      if (something == null)
      {
        return NotFound(new ApiResponse(404));
      }
      return Ok();
    }

    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
      var something = _db.Places.Find(1660);
      var returnSomething = something.ToString();
      return Ok();
    }

    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {
      return BadRequest(new ApiResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public ActionResult GetBadRequest(int id)
    {
      return BadRequest(new ApiResponse(400));
    }
  }
}