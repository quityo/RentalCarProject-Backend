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





        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rental
                             join c in context.Car
                             on r.CarId equals c.CarId
                             join cstmr in context.Customer
                             on r.CustomerId equals cstmr.CustomerId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 CompanyName = cstmr.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return filter == null
                   ? result.ToList()
                   : result.Where(filter).ToList();
            }
        }
    }
}