using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost("add")]
        public IActionResult Add(IFormFile image,[FromForm]CarImage carImage)
        {
            _carImageService.Add(image,carImage);
            return Ok();    
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            _carImageService.Delete(id);
            return Ok ();
        }

        [HttpPost("update")]
        public IActionResult Update(IFormFile file,[FromForm]int id)
        {
            _carImageService.Update(file, id);
            return Ok();
        }




    }
}
