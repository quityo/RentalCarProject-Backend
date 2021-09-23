using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in context.Rental
                             join car in context.Car on rental.CarId equals car.CarId
                             join customer in context.Customer on rental.CustomerId equals customer.CustomerId
                             join user in context.User on customer.UserId equals user.UserId
                             join brand in context.Brand on car.BrandId equals brand.BrandId
                             join color in context.Color on car.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {

                                 RentalId = rental.RentalId,
                                 CompanyName = customer.CompanyName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 CarId = rental.CarId,
                                 ModelYear = car.ModelYear,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        
    }
}