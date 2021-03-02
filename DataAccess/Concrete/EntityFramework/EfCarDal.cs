using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join clr in context.Color
                             on c.ColorId equals clr.ColorId
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice
                             };

                return result.ToList(); 
            }
        }

        public CarDetailDto GetCarDetailsById(Expression<Func<CarDetailDto, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Car
                         join b in context.Brand
                         on c.BrandId equals b.BrandId
                         join clr in context.Color
                         on c.ColorId equals clr.ColorId
                         select new CarDetailDto()
                         {
                             CarId = c.CarId,
                             CarName = c.CarName,
                             BrandName = b.BrandName,
                             ColorName = clr.ColorName,
                             DailyPrice = c.DailyPrice
                         };

            return result.SingleOrDefault(filter);
        }
    }
    }
}
