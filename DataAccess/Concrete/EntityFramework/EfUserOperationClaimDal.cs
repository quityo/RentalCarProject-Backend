using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, RentACarContext>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDto> GetUserOperationClaimDetails(Expression<Func<UserOperationClaim, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from uoc in filter == null ? context.UserOperationClaim : context.UserOperationClaim.Where(filter)
                             join u in context.User
                             on uoc.UserId equals u.UserId
                             join oc in context.OperationClaim
                             on uoc.OperationClaimId equals oc.OperationClaimId
                             select new UserOperationClaimDto
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 OperationClaimId = oc.OperationClaimId,
                                 UserId = uoc.UserId,
                                 Id = uoc.Id,
                                 Name = oc.Name,
                             };
                return result.ToList();
            }
        }
        public UserOperationClaimDto GetUserOperationClaimDetail(Expression<Func<UserOperationClaimDto, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from uoc in context.UserOperationClaim
                             join u in context.User on uoc.UserId equals u.UserId
                             join oc in context.OperationClaim
                              on uoc.OperationClaimId equals oc.OperationClaimId
                             select new UserOperationClaimDto
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 OperationClaimId = oc.OperationClaimId,
                                 UserId = uoc.UserId,
                                 Id = uoc.Id,
                                 Name = oc.Name,
                             };
                return result.SingleOrDefault(filter);
            }
        }
    }
    
}
