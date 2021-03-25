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
    public class EFRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {


        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rental
                             join cu in context.Customer on r.CustomerId equals cu.CustomerId
                             join ca in context.Car on r.CarId equals ca.CarId
                             join u in context.User on cu.UserId equals u.UserId

                             select new RentalDetailDto
                             {
                                 CarId = ca.CarId,
                                 CarName = ca.CarName,
                                 UserId = u.UserId,
                                 CustomerId = cu.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}