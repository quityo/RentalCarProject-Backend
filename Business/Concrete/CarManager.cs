using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Performance;

using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        //[CacheRemoveAspect("car")]
        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("car")]
        //[TransactionAspect]
        [PerformanceAspect(1)]
        public IResult AddTransactionTest(Car entity)
        {
            Thread.Sleep(2000);
            _carDal.Add(entity);
            if (entity.BrandId == 0)
            {
                throw new Exception("");
            }
            entity.CarId = 0;
            entity.Description = "TransactionTest" + entity.Description;
            _carDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("car.update")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            if (car.CarName.Length < 3) return new ErrorResult(Messages.CarNameInvalid);
            if (car.DailyPrice <= 0) return new ErrorResult(Messages.CarDailyPriceInvalid);
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        [SecuredOperation("car.delete")]
        public IResult Delete(Car car)
        {
            _carImageService.DeleteByCarId(car.CarId);
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetCarsByBrandId(brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetCarsByColorId(colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
           
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
