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
            if(rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult("Araç Kullanımdadır.");
        }
        public IResult Update(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Updated);
            }
            return new ErrorResult("Araç Kullanımda olduğundan Silinme işlemi yapılamaz.");
        }
        public IResult Delete(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.Deleted);
            }
            return new ErrorResult("Araç Kullanımda olduğundan Silinme işlemi yapılamaz.");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.GetAll);
        }

       
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.GetRentalDetails);
        }

        public IDataResult<RentalDetailDto> GetRentalDetailsById(int rentalId)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetailsById(r => r.RentalId == rentalId), Messages.GetRentalDetailsById);
        }

        public IDataResult<List<Rental>> GetById(int rentalId)
        {
            throw new NotImplementedException();
        }
    }
}
