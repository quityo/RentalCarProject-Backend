
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;

using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (var context = new RentACarContext())
            {
                var result = from c in context.Customer
                             join u in context.User on c.UserId equals u.UserId

                             select new CustomerDetailDto
                             {
                                 CustomerId = c.CustomerId,


                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();

                
            }
        }

    }
}
