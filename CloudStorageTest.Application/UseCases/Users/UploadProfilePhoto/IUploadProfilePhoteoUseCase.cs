using Microsoft.AspNetCore.Http;

namespace CloudStorageTest.Application.UseCases.Users.UploadProfilePhoto;

public interface IUploadProfilePhoteoUseCase
{
    public void Execute(IFormFile file);
}
