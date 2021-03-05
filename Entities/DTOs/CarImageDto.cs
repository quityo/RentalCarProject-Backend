using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDto : IDto
    {
        public int ImageId { get; set; }
        public int CarId { get; set; }
        public IFormFile ImagePath { get; set; }
    }
}
