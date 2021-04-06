using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Car
                             join color in context.Color
                             on car.ColorId equals color.ColorId
                             join brand in context.Brand
                             on car.BrandId equals brand.BrandId
                             join image in context.CarImage
                             on car.CarId equals image.CarId
                             select new CarDetailDto
                             {
                                 CarName = car.CarName,
                                 CarId = car.CarId,
                                 BrandId = car.BrandId,
                                 ColorId = car.ColorId,
                                 ColorName = color.ColorName,
                                 BrandName = brand.BrandName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 ImagePath = image.ImagePath

                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}