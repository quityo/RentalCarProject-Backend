using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Business.Concrete
{
    public class RentalManager : IRentalService

    {
        IRentalDal _rentalDal;
        ICarService _carService;
        ICustomerService _customerService;
        public RentalManager(IRentalDal rentalDal, ICarService carService, ICustomerService customerService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _customerService = customerService;
        }
        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            var car = _carService.GetById(entity.CarId).Data;
            car.Status = true;
            _carService.Update(car);
            return new SuccessResult("Rental Add");
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }
        public IDataResult<Rental> Get(Rental entity)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.RentalId == entity.RentalId));
        }

        public IResult GetList(List<Rental> list)
        {
            Console.WriteLine("\n------- Rental List -------");
            foreach (var rental in list)
            {
                Console.WriteLine("{0}- Car Id: {1}\n   Customer Id: {2}\n   Rent Date: {3}\n   Return Date: {4}\n", rental.RentalId, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
            return new SuccessResult();
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
       

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.CarId == carId), Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == customerId));
        }
        public bool IsCarAvailable(int carId)
        {
            Rental result = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
            return result == null ? true : false;
        }

        public IResult CarIsReturned(int carId)
        {
            Rental result = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
            result.ReturnDate = DateTime.Now;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            Rental r = new Rental();
            if (_rentalDal.GetAll().Any(x => x.RentalId == rentalId))
            {
                r = _rentalDal.GetAll().FirstOrDefault(x => x.RentalId == rentalId);
            }
            else Console.WriteLine("NotExist" + "rental");
            return new SuccessDataResult<Rental>(r);
        }

        public IResult CheckIfFindeks(int carId, int customerId)
        {
            var customer = _customerService.GetById(customerId).Data;
            var car = _carService.GetById(carId).Data;
            if (customer.CustomerFindex < car.CarFindex)
            {
                return new ErrorResult("NotEngouhFindeks");
            }
            return new SuccessResult("EngouhFindeks");
        }
    }
}