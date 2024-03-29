﻿using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Car : IEntity
    {

        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int CarFindex { get; set; }
        public bool Status { get; set; }
    }
}
