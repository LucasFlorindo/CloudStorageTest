using CloudStorageTest.Application.UseCases.Users.UploadProfilePhoto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CloudStorageTest.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{

    [HttpPost]
    
    public IActionResult UploadImage(
        [FromServices] IUploadProfilePhoteoUseCase useCase,
        IFormFile file)
    {
        useCase.Execute(file);

        return Created();
    }
}
