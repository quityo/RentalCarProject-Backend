using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rental
                             join c in context.Car on r.CarId equals c.CarId
                             join cu in context.Customer on r.CustomerId equals cu.UserId
                             join b in context.Brand on c.BrandId equals b.BrandId
                             join u in context.User on cu.UserId equals u.UserId
                             join co in context.Color on c.ColorId equals co.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarName=b.BrandName,
                                 DailyPrice =c.DailyPrice,
                                 ColorName=co.ColorName,
                                 CompanyName = cu.CompanyName,
                                 UserName = u.FirstName + " " + u.FirstName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();


            }
        }
    }
}
