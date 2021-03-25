﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int ImageId { get; set; }

        [Key]
        public int CarId { get; set; }
        
        public string ImagePath { get; set; }
        public DateTime Created { get; set; }
        
    }
}
