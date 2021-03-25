using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
    }
}
