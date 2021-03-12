using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             where c.BrandId == brandId
                             select c;

                return result.ToList();
            }
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Car
                             join cl in context.Color
                             on c.ColorId equals cl.ColorId
                             where c.ColorId == colorId
                             select c;

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Car
                             join co in context.Color
                             on c.ColorId equals co.ColorId
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
