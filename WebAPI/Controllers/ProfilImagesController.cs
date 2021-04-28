using Business.Abstract;
using Entities.DTOs;
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
    public class ProfilImagesController : ControllerBase
    {
        IProfilImageService _profilImageService;

        public ProfilImagesController(IProfilImageService profilImageService)
        {
            _profilImageService = profilImageService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _profilImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyprofilimageid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int ProfilImageId)
        {
            var result = _profilImageService.Get(ProfilImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] ProfilImagesDto profilImagesDto)
        {
            var result = _profilImageService.Add(profilImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] ProfilImagesDto profilImagesDto)
        {
            var result = _profilImageService.Update(profilImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ProfilImagesDto profilImagesDto)
        {
            var result = _profilImageService.Delete(profilImagesDto);
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getimagesbyuserid")]
        public IActionResult GetImagesByUserId(int userId)
        {
            var result = _profilImageService.GetImagesByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }
}
