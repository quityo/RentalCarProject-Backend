using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (var context = new RentACarContext())
            {
                var result = from r in context.Rental
                             join c in context.Customer on r.CustomerId equals c.UserId
                             join u in context.User on c.UserId equals u.UserId
                             select new RentalDetailDto
                             { 
                                 RentalId = r.RentalId,
                                 CarId = r.CarId,
                                 CustomerId = r.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                             };
                return result.ToList();

            };

                
            
        }
    }
}