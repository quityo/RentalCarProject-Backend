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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from a in context.Car 
                             join b in context.Brand 
                             on a.BrandId equals b.BrandId
                             join abc in context.Color 
                             on a.ColorId equals abc.ColorId
                             select new CarDetailDto 
                             {
                                 
                                 CarName = a.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = abc.ColorName,
                                 DailyPrice = a.DailyPrice
                             };

                return result.ToList(); 
            }
        }
    }
}
