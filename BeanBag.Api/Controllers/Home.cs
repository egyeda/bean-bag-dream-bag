using Microsoft.AspNetCore.Mvc;

namespace BeanBag.Api.Controllers;

public class Home : ControllerBase
{
    [HttpGet]
    [Route("api/home")]
    public string Index()
    {
        return "Hello World!";
    }
}