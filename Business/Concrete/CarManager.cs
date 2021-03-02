using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
       //[LogAspect]
       //[Validate]
       //[RemoveCache]
       //[Transaction]
       //[Performance]
        public IResult Add(Car car)
        { 
            if (car.CarName.Length >=2 && car.DailyPrice>0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                return new ErrorResult(Messages.CarCanNotAdded);
            }
                   
        }
        public IResult Update(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.Updated);

            }
            else
            {
                return new ErrorResult(Messages.CarCanNotUpdated);
            }
        }
        public IResult Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {
                throw new Exception("Sistem Hatası.");
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            
        
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.GetAll);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId), Messages.GetCarByCarId);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.GetCarsByBrandId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.GetCarsByColorId);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.GetCarsWithDetails);
        }

        public object GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsById(c => c.CarId == carId), Messages.GetCarDetailsById);
        }
    }
}
