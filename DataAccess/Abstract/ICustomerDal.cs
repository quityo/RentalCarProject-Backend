﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    namespace DataAccess.Abstract
    {
        public interface ICustomerDal : IEntityRepository<Customer>
        {
            List<CustomerDetailDto> GetCustomerDetail(Expression<Func<Customer, bool>> filter = null);
            CustomerDetailDto getCustomerByEmail(Expression<Func<CustomerDetailDto, bool>> filter);
        }
    }
    
}