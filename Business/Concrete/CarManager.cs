using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void Add(Car car)
        { 
            if (car.CarName.Length >=2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("{0} Added", car.CarName);
            }
            else
            {
                Console.WriteLine("Car's name must be longer than 2 and daily price must be bigger than 0!!");
            }
                   
        }
        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public List<Car> GetByBrandId(int brandId)
        { 
            return _carDal.GetAll(p => p.BrandId == brandId);
        }
        public List<Car> GetByColorId(int colorId)

        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }
    }
}
