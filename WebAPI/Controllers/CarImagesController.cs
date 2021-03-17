using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int imageId)
        {
            var result = _carImageService.Get(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagesbycarid")]
        public IActionResult GetCarImagesById([FromForm] int carId)
        {
            var result = _carImageService.GetCarImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] CarImage carImage)
        {
            carImage.Created = DateTime.Now;
            carImage.ImagePath = FileHelper.Add(file);
            var result = _carImageService.Add(carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int ImageId)
        {
            var carImage = _carImageService.Get(ImageId).Data;

            _ = _carImageService.Get(ImageId).Data;
            
            var oldPath = Path.Combine(Environment.CurrentDirectory, "wwwroot", _carImageService.Get(ImageId).Data.ImagePath);

            FileHelper.Delete(oldPath);

            var result = _carImageService.Delete(carImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int ImageId)
        {
            var carImage = _carImageService.Get(ImageId).Data;
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }



}