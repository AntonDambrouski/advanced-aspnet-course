using Microsoft.AspNetCore.Http;

namespace MovieManager.Core.Interfaces;
public interface IFileUploadService
{
    Task UploadFileAsync(string pathToSave, string fileName, IFormFile file);
}
