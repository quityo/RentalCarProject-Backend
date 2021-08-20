using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<string>> GetUserClaims(int userId);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult ProfileUpdate(User user, string password);
        IDataResult<List<UserDetailDto>> GetUserDetail(int userId);
        IDataResult<List<UserDetailDto>> GetUserDetails();
    }
}