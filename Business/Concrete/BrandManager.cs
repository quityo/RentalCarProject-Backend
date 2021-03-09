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
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        //[SecuredOperation("brand.add, admin")] 
        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }
        [ValidationAspect(typeof(BrandValidator))]
        //[SecuredOperation("brand.update, admin")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
        [ValidationAspect(typeof(BrandValidator))]
        //[SecuredOperation("brand.delete, admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<List<BrandDetailDto>> GetBrandDetails()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(br => br.BrandId == brandId));
        }

       
    }
}
