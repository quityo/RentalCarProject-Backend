using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentACarContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentACarContext())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOperationClaim in context.UserOperationClaim
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserDetailDto GetUserDetail(Expression<Func<UserDetailDto, bool>> filter)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.User
                             join c in context.Customer
                             on u.UserId equals c.UserId
                             join r in context.Rental
                             on c.CustomerId equals r.CustomerId
                             join car in context.Car on r.CarId equals car.CarId
                             join b in context.Brand on car.BrandId equals b.BrandId
                             let pi = context.UserImage.Where(x => x.UserId == c.UserId).FirstOrDefault()
                            
                             select new UserDetailDto()
                             {
                                 CarName = car.CarName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 Email = u.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate,
                                 BrandName = b.BrandName,
                                 UserId = u.UserId,
                             };
                return result.SingleOrDefault(filter);
            }
        }
      
        public List<UserDetailDto> GetUserDetails(Expression<Func<User, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in filter == null ? context.User : context.User.Where(filter)
                             join c in context.Customer
                             on u.UserId equals c.UserId
                             let pi = context.UserImage.Where(x => x.UserId == c.UserId).FirstOrDefault()

                             select new UserDetailDto
                             {

                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 Email = u.Email,
                                 UserId = u.UserId,
                                 ImagePath = context.UserImage.Where(x => x.UserId == u.UserId).FirstOrDefault().ImagePath,

                               

                             };
                return result.ToList();
            }
            
        }

    }
}
