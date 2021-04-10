
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
        public List<CustomerDetailDto> GetCustomerDetail(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from customer in context.Customer
                             join u in context.User
                             on customer.CustomerId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = customer.CompanyName,
                                 Email = u.Email

                             };
                return result.ToList();
            }
        }
    }
}