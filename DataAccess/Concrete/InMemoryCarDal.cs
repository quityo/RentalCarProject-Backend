using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car() {CarId = 1, BrandId = 1, ColorId = 1, CarName = "Black Samurai", Description = "Higway Man", ModelYear = 1977, DailyPrice = 1111.11M},
                new Car() {CarId = 2, BrandId = 2, ColorId = 1, CarName = "Black Sun", Description = "Black Hole Sun", ModelYear = 1979, DailyPrice = 2222.22M},
                new Car() {CarId = 3, BrandId = 3, ColorId = 2, CarName = "Red Baron", Description = "Moulin Rouge", ModelYear = 1975, DailyPrice = 3333.33M},
                new Car() {CarId = 4, BrandId = 4, ColorId = 3, CarName = "Daisey", Description = "Love Me 2 Times", ModelYear = 1978, DailyPrice = 4444.44M},
                new Car() {CarId = 5, BrandId = 5, ColorId = 1, CarName = "Shadow", Description = "Shadow Rider", ModelYear = 1979, DailyPrice = 5555.55M}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarName = car.CarName;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }
        public List<Car> GetAll()
        {
            return _cars;
        }
        public Car GetCarById(int carId)
        {
            return _cars.SingleOrDefault(p => p.CarId == carId);
        }
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
                
        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
        public CarDetailDto GetCarDetailsById(Expression<Func<CarDetailDto, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
