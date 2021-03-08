using Core.Entities;
using System;


namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int RentalId { get; set; }
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int CustomerId { get; set; }
        public int ColorId { get; set; }
        
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int RentOfficeId { get; set; }
        public int ReturnOfficeId { get; set; }
    }
}
