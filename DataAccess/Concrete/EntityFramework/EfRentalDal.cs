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
            public List<RentalDetailDto> GetRentalDetails()
            {
                using (RentACarContext contex = new RentACarContext())
                {
                    var result = from r in contex.Rental
                                 join c in contex.Car
                                 on r.CarId equals c.CarId
                                 join cus in contex.Customer
                                 on r.CustomerId equals cus.CustomerId
                                 join us in contex.User
                                 on cus.UserId equals us.UserId
                                 select new RentalDetailDto
                                 {
                                     RentalId = r.RentalId,
                                     CarName = c.CarName,
                                     FirstName = us.FirstName,
                                     LastName = us.LastName,
                                     RentDate = r.RentDate,
                                     ReturnDate = r.ReturnDate

                                 };

                    return result.ToList();
                }

            }


        }
}