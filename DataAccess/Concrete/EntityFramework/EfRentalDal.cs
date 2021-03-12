using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{

    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rental
                             join cs in context.Customer
                             on r.CustomerId equals cs.CustomerId
                             join u in context.User
                             on cs.UserId equals u.UserId
                             join c in context.Car
                             on r.CarId equals c.CarId
                             join cl in context.Color
                             on c.ColorId equals cl.ColorId
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 BrandName = b.BrandName,
                                 Description = c.Description,
                                 ColorName = cl.ColorName,
                                 CompanyName = cs.CompanyName,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 ModelYear = c.ModelYear
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

    }
}
