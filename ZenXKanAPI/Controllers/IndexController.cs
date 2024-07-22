using Microsoft.AspNetCore.Mvc;

namespace ZenXKanAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class IndexController : ControllerBase
{
   [HttpGet("/healthcheck")]
   public string HealthCheck()
   {
      return "API is running fine dude.";
   }
   
}