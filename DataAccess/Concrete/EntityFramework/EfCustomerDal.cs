
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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {

                var result = from customer in context.Customer
                             join user in context.User
                             on customer.UserId equals user.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                             };

                return result.ToList();
            }
        }
    }
}

