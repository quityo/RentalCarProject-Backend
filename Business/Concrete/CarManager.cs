using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Performance;
using Core.Aspects.AutoFac.Transaction;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
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

        [ValidationAspect(typeof(CarValidator))] //s1
        [SecuredOperation("car.add, admin")] //s2.
        [CacheRemoveAspect("ICarService.Get")] //s3
        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }


        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }


        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 100)
            {
                 
                throw new Exception("Transaction Error");
            }
            Add(car);
            return null;
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
