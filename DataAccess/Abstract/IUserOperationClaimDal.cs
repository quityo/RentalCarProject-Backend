using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimDto> GetUserOperationClaimDetails(Expression<Func<UserOperationClaim, bool>> filter = null);
    }
}