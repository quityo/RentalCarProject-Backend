using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {

        IDataResult<List<UserOperationClaim>> GetAll();
        IDataResult<UserOperationClaim> GetById(int id);
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        IDataResult<List<UserOperationClaimDto>> GetUserOperationClaimDetails();
        IDataResult<List<UserOperationClaimDto>> GetUserOperationClaimDetail(int id);
        IDataResult<List<UserOperationClaimDto>> GetNameById(int id);
    }
}
