using Microsoft.AspNetCore.Mvc.RazorPages;
using ServerlessAspNetCore.Domain;

namespace ServerlessAspNetCore.Services
{
    public interface IImageService
    {
        public Task<List<ImageModel>> GetAllImages();
        Task<List<ImageModel>> GetAllImagesDynamoDB();
    }
}
