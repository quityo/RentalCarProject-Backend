using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConcoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User
            //{
            //    UserId = 7,
            //    FirstName = "FuFu",
            //    LastName = "Fu",
            //    Email = "Fu@Ty.com",
            //    Password = "65f32"
            //});
            //foreach (var user in userManager.GetAll().Data)
            //{
            //    Console.WriteLine("UserId: {0} FirstName: {1} LastName: {2} Email: {3} Password: {4}", user.UserId, user.FirstName, user.LastName, user.Email, user.Password);
            //}
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer
            //{
            //    CustomerId = 4,
            //    CompanyName = "Peace 'n Love"
            //});
            //var result = customerManager.GetAll();
            //if (result.Success)
            //{
            //    foreach (var customer in result.Data)
            //       {
            //            Console.WriteLine(customer.CompanyName);
            //       }
            //}

            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental
            //{
            //    RentalId = 3,
            //    CarId = 3,
            //    CustomerId = 3,
            //    RentDate = new DateTime(2021, 3, 02),
            //    ReturnDate = new DateTime(2021, 3, 15)
            //});

            //foreach (var rental in rentalManager.GetAll().Data)
            //{
            //    Console.WriteLine("RentalId: {0} CarId: {1} CustomerId: {2} RentDate: {3} ReturnDate: {4}", rental.RentalId, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            //}

            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                rentalManager.Add(new Rental
                {
                    CustomerId = 5,
                    CarId = 1011,
                    RentDate = new DateTime(2021, 06, 04),
                    ReturnDate = new DateTime(2021, 06, 09),
                    BrandId = 1008,
                    ColorId = 7
                });
            }
            carManager.Add(new Car
            {
                CarId = 6,
                BrandId = 2,
                ColorId = 2,
                CarName = "T-Model",
                ModelYear = 1944,
                DailyPrice = 6666,

                Description = "Kolleksiyon Parçası"
            });

            carManager.GetCarDetails();

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Marka: " + car.BrandName + "\n" + "Yıl: " + car.ModelYear + "\n" + "Renk: "
                    + car.ColorName + "\n" + "İsim: " + car.CarName + "\n" + "Ücret: " + car.DailyPrice + "\n" + "Açıklama: " + car.Description);
                Console.WriteLine("------------");
            }
            customerManager.GetAll();
            if (result.Success == true)
            {
                customerManager.Add(new Customer
                {
                    CompanyName = "Funky Sun"
                });
            }
            

        }
    }
}

