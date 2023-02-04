using Microsoft.AspNetCore.Mvc;

namespace BeanBag.Api.Controllers;

[Route("api/images")]
public class ImagesController : ControllerBase 
{
    private readonly IWebHostEnvironment _env;

    public ImagesController(IWebHostEnvironment env)
    {
        _env = env;
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile image)
    {
        var mime = image.FileName.Split('.').Last();
        var fileName = string.Concat(Path.GetRandomFileName(), ".", mime);
        var savePath = Path.Combine(_env.WebRootPath, fileName);

        await using(var fileStream = new FileStream(savePath, FileMode.Create, FileAccess.Write))
        {
            await image.CopyToAsync(fileStream);
        }
        
        return Ok();
    }
}