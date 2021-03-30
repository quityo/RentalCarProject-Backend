using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public bool CheckCarStatus(int carId, DateTime rentDate, DateTime? returnDate)
        {
            using (RentACarContext context = new RentACarContext())
            {
                bool checkReturnDateIsNull = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);
                bool isValidRentDate = context.Set<Rental>()
                    .Any(r => r.CarId == carId && (
                            (rentDate >= r.RentDate && rentDate <= r.ReturnDate) ||
                            (returnDate >= r.RentDate && returnDate <= r.ReturnDate) ||
                            (r.RentDate >= rentDate && r.RentDate <= returnDate)
                            )
                    );

                if ((!checkReturnDateIsNull) && (!isValidRentDate))
                {
                    return true;
                }

                return false;
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from ra in context.Rental
                             join c in context.Car
                             on ra.CarId equals c.CarId
                             join co in context.Customer
                             on ra.CustomerId equals co.CustomerId
                             join u in context.User
                             on co.UserId equals u.UserId
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join p in context.Payment
                             on ra.PaymentId equals p.PaymentId
                             
                             select new RentalDetailDto
                             {
                                 RentalId = ra.RentalId,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CustomerName = co.CompanyName,
                                 RentDate = ra.RentDate,
                                 ReturnDate = ra.ReturnDate,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 AmountPaye = p.AmountPaye

                             };
                return result.ToList();
            }
        }
    }
}