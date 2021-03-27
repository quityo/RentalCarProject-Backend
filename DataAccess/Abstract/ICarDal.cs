using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail();
        List<CarDetailDto> GetByBrandDetails(int brandId);
        List<CarDetailDto> GetByColorDetails(int colorId);
    }
}
