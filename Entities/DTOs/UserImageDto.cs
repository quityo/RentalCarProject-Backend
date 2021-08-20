using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserImageDto : IDto
    {
        public int ImageId { get; set; }
        public int UserId { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
