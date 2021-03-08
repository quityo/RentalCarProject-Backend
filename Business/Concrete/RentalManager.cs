using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        { 
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            
        }
        public IResult Update(Rental rental)
        {
            var updatedRental = _rentalDal.Get(p => p.CarId == rental.CarId);
            if (updatedRental.ReturnDate != null)
            {
                return new ErrorResult("The car has not been returned, it can not be updated yet!");
            }
            updatedRental.ReturnDate = DateTime.Now;
            _rentalDal.Update(updatedRental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.Deleted);
            
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.GetAll);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId), Messages.GetRentalByRentalId);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.GetRentalDetails);
        }

        
    }
}
