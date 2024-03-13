using CloudStorageTest.Domain.Entities;
using CloudStorageTest.Domain.Storage;
using FileTypeChecker;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageTest.Application.UseCases.Users.UploadProfilePhoto;

public class UploadProfilePhoteoUseCase : IUploadProfilePhoteoUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfilePhoteoUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }
    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();

        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

        if (isImage == false)
            throw new Exception("The file is not an image");

        var user = GetFromDatabase();

        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Lucas",
            Email = "lucasrfurini@gmail.com",
            AccessToken = "ya29.a0Ad52N397M9RaJWgPIz4QgywjduwQRikodbeD0XS2KsWc5AEwsxU8VUyP7uGpetLLUEm230lpTsrHf74MA4w5Ru67-cw6De-umon0WFQn3HXwp-8Y-tQFddRAwWh7w7EX27W9h-p7rB2qb0SBBnu74hxshEhfbyefQUTfaCgYKAe8SAQ4SFQHGX2Mit43Q700IStQ9ZxM2xfu3cA0171",
            RefreshToken = "1//04DU6Ot78ppIrCgYIARAAGAQSNwF-L9IrPwocPsnQIqRwFmkMdx6RiNqWucV32_9kKMgKIVXk45UAdHViREF3NlC3S4on2fRUqOI"
        };
    }
}
