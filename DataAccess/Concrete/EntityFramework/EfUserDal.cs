using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.Utilities.Results;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOperationClaim in context.UserOperationClaim
                                 on operationClaim.Id equals userOperationClaim.Id
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return new SuccessDataResult<List<OperationClaim>>(result.ToList());

            }
        }
    }
}
