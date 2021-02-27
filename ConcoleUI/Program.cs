using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConcoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Marka: " + car.BrandName + "\n"  + "Yıl: " + car.ModelYear + "\n" + "Renk: " 
                    + car.ColorName + "\n" + "İsim: " + car.CarName + "\n" +  "Ücret: "  + car.DailyPrice + "\n" + "Açıklama: " + car.Description);
                Console.WriteLine("------------");
            }
        }
    }
}
