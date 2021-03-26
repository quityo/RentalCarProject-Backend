using Business.Concrete;
using Business.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConcoleUI
{
    class Program
    {


        static void Main(string[] args)
        {
            Color color = CreateColor("Black");
            Brand brand = CreateBrand("Opel");
            Car car = CreateCar(brand, color, 2007, 270, "Car Description...");
            User user = CreateUser("Name", "SurName", "mail@mail.com", "12345");
            Customer customer = CreateCustomer(user, "Company Name");

            ListCars();

            RentACar(user, car, customer);
            RentACar(user, car, customer); // aynı aracı ikinci kez kiralamaya çalışıyoruz... error dönüyor

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.CarIsReturned(car.CarId); // araç iade ediliyor

            RentACar(user, car, customer); // tekrar kiralandı.

        }

        private static void RentACar(User user, Car car, Customer customer)
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental();
            rental.CarId = car.CarId;
            rental.CustomerId = customer.CustomerId;
            rental.RentDate = DateTime.Now;
            rental.ReturnDate = DateTime.UtcNow;
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }

        private static User CreateUser(string firstName, string lastName, string email, string password)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            var result = userManager.Add(user);
            Console.WriteLine(result.Message);
            return user;
        }

        private static Customer CreateCustomer(User user, string companyName)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer();
            customer.CompanyName = companyName;
            customer.UserId = user.UserId;
            var result = customerManager.Add(customer);
            Console.WriteLine(result.Message);
            return customer;
        }

        private static Color CreateColor(string color)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color _color = new Color();
            _color.ColorName = color;
            var result = colorManager.Add(_color);
            Console.WriteLine(result.Message);
            return _color;
        }

        private static Brand CreateBrand(string brand)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand _brand = new Brand();
            _brand.BrandName = brand;
            var result = brandManager.Add(_brand);
            Console.WriteLine(result.Message);
            return _brand;
        }

        private static Car CreateCar(Brand brand, Color color, int modelYear, decimal dailyPrice, string description)
        {
            CarManager carManager = new CarManager(new EfCarDal(), new CarImageManager(new EfCarImageDal()));
            Car car = new Car();
            car.CarName = brand.BrandName;
            car.BrandId = brand.BrandId;
            car.ColorId = color.ColorId;
            car.ModelYear = modelYear;
            car.DailyPrice = dailyPrice;
            car.Description = description;
            var result = carManager.Add(car);
            Console.WriteLine(result.Message);
            return car;
        }

        private static void ListCars()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new CarImageManager(new EfCarImageDal()));
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araç: " + car.BrandName + " Color: " + car.ColorName + " Fiyat: " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}