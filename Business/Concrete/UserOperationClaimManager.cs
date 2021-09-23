using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim entity)
        {
            _userOperationClaimDal.Add(entity);
            return new SuccessResult("UserOperationClaim Added");
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {

            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult("UserOperationClaim Deleted");
        }
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult("OperationClaim Updated");
        }
        public IDataResult<List<UserOperationClaim>> GetAll()
        {

            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(), "UserOperationClaim Listed");
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(b => b.Id == id));
        }


        public IDataResult<List<UserOperationClaimDto>> GetUserOperationClaimDetails()
        {
            List<UserOperationClaimDto> operationDetails = _userOperationClaimDal.GetUserOperationClaimDetails();
            if (operationDetails == null)
            {
                return new ErrorDataResult<List<UserOperationClaimDto>>();
            }
            else
            {
                return new SuccessDataResult<List<UserOperationClaimDto>>(operationDetails);
            }
        }

        public IDataResult<List<UserOperationClaimDto>> GetUserOperationClaimDetail(int id)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.GetUserOperationClaimDetails(c => c.Id == id));
        }

        

        public IDataResult<List<UserOperationClaimDto>> GetNameById(int id)
        {

            return new SuccessDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.GetUserOperationClaimDetails(c => c.Id == id));

        }
    }
}