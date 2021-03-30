
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
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.User
                             join c in context.Customer
                             on u.UserId equals c.UserId
                             select new CustomerDetailDto { 
                                 CustomerId = c.CustomerId, 
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName, 
                                 Email = u.Email, 
                                 PasswordSalt = u.PasswordSalt, 
                                 PasswordHash = u.PasswordHash, 
                                 CompanyName = c.CompanyName };
                return result.ToList();
            }
        }
    }
}


