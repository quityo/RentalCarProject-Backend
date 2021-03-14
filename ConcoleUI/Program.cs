using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConcoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                Console.WriteLine("Test:  \nCar Name\tBrand Name\tColor Name\tDaily Price");
                foreach (var car in result.Data)
                {
                    Console.WriteLine(
                        $"{car.Description}\t\t{car.CarName}\t\t{car.Description}\t\t{car.DailyPrice}");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            Console.WriteLine("\n");

            Rental rent = new Rental
            {
                CarId = 2304,
                CustomerId = 8,
                RentDate = "1923",
            };
            var rentalResult = rentalManager.Add(rent);

            Console.WriteLine(rentalResult.Message);

            Console.ReadLine();
        }

        
    }
}

