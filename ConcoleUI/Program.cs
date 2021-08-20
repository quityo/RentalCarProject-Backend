using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConcoleUI
{
    class Program
    {
      

        private static void RentACar(User user, Car car, Customer customer)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.CarId = car.CarId;
            rental.CustomerId = customer.CustomerId;
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = null;
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }

    }
}