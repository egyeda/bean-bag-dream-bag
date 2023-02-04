using Microsoft.AspNetCore.Mvc;

namespace BeanBag.Api.Controllers;

public class Home : Controller
{
    [HttpGet]
    [Route("api/home")]
    public string Index()
    {
        return "Hello World!";
    }
}