
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in filter == null ? context.Rental : context.Rental.Where(filter)
                             join car in context.Car on rental.CarId equals car.CarId
                             join customer in context.Customer on rental.CustomerId equals customer.CustomerId
                             join user in context.User on customer.UserId equals user.UserId
                             join brand in context.Brand on car.BrandId equals brand.BrandId
                             join color in context.Color on car.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {

                                 RentalId = rental.RentalId,
                                 CompanyName = customer.CompanyName,
                                 CarDailyPrice = car.DailyPrice,
                                 CarDescription = car.Description,
                                 CarId = rental.CarId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}

