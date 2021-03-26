using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImageDto carImagesDto)
        {
            var result = _carImageService.Add(carImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImageDto carImagesDto)
        {
            var result = _carImageService.Update(carImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImageDto carImagesDto)
        {
            var result = _carImageService.Delete(carImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("deletebycarid")]
        public IActionResult DeleteByCarId(int carId)
        {
            var result = _carImageService.DeleteByCarId(carId);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int imageId)
        {
            var result = _carImageService.GetById(imageId);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (!result.Success) return BadRequest();
            return Ok(result);
        }

        [HttpGet("getlist")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }
    }
}