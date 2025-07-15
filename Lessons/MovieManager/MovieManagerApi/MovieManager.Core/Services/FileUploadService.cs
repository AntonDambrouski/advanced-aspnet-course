using Microsoft.AspNetCore.Http;
using MovieManager.Core.Interfaces;

namespace MovieManager.Core.Services;
public class FileUploadService : IFileUploadService
{
    private readonly string FolderUploadPath;

    public FileUploadService(string uploadPath)
    {
        FolderUploadPath = uploadPath;
    }

    public async Task UploadFileAsync(string pathToSave, string fileName, IFormFile file)
    {
        var filePath = Path.Combine(FolderUploadPath, pathToSave);
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        var fullPath = Path.Combine(filePath, fileName);
        using(var stream = new FileStream(fullPath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
    }
}
