﻿using Core.Entities;
using System;


namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public string ColorName { get; set; }
        public string CarName { get; set; }
        public string UserName { get; set; }
        
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal DailyPrice { get; set; }
        public string CompanyName { get; set; }

    }
}