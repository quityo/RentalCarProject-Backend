using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        [ValidationAspect(typeof(RentalValidator))] 
        //[SecuredOperation("rental.add, admin")] 
        public IResult Add(Rental rental)
        {
            
            var result = _rentalDal.Get(c => c.CarId == rental.CarId &&
                        (c.ReturnDate == null || c.ReturnDate > DateTime.Now));
            if (result != null)
            {
                
                return new ErrorResult(Messages.GetRentalDetails);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.GetRentalDetails);
        }
        [ValidationAspect(typeof(RentalValidator))]
        //[SecuredOperation("rental.update, admin")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);

        }
        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("rental.delete, admin")]

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }


        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }



        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }


        
    }
}
