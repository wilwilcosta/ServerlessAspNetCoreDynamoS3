using Microsoft.AspNetCore.Mvc;
using ServerlessAspNetCore.Domain;
using ServerlessAspNetCore.Services;

namespace ServerlessAspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {

        private readonly IImageService _imageService;
        private readonly ILogger<ImageController> _logger;

        public ImageController(ILogger<ImageController> logger, IImageService imageService)
        {
            _logger = logger;
            _imageService = imageService;
        }

        [HttpGet(Name = "Images")]
        public async Task<IActionResult> Get()
        {
            var response = await _imageService.GetAllImages();
            if(response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
