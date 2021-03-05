using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        private EfCarDal efCarDal;

        //IBrandService _brandService;
        public CarManager(ICarDal carDal, ILogger logger)
        {
            _carDal = carDal;
            //_brandService = brandService;
        }

        public CarManager(EfCarDal efCarDal)
        {
            this.efCarDal = efCarDal;
        }

        [ValidationAspect(typeof(CarValidator))]
       
        public IResult Add(Car car)
        {
            
                _carDal.Add(car);

                return new SuccessResult(Messages.Added);
            
                      
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {            
            _carDal.Update(car); 
            
            return new SuccessResult(Messages.Updated); 
            
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
        
            if (DateTime.Now.Hour == 13)
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

        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(p => p.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlredyExists);
            }
            return new SuccessResult();
        }
    }
}
