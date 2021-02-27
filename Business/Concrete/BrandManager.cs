using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)

        {
            _brandDal.Add(brand);
        }
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);

        }
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll().ToList();
        }
        public Brand GetById(int brandId)
        {
            return _brandDal.Get(p => p.BrandId == brandId);
        }

        Brand IBrandService.GetById(int brandId)
        {
            throw new NotImplementedException();
        }
    }
}
