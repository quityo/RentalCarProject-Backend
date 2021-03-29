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
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in context.Rental
                             join car in context.Car
                             on rental.CarId equals car.CarId
                             join customer in context.Customer
                             on rental.CustomerId equals customer.UserId
                             join user in context.User
                             on customer.UserId equals user.UserId
                             join brand in context.Brand
                             on car.BrandId equals brand.BrandId

                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 BrandName = brand.BrandName,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}