using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IDataResult<UserOperationClaim> GetById(int userOperationClaimId)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(b => b.UserOperationClaimId == userOperationClaimId));
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

        public IDataResult<List<UserOperationClaimDto>> GetUserOperationClaimDetail(int userOperationClaimId)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(_userOperationClaimDal.GetUserOperationClaimDetails(c => c.UserOperationClaimId == userOperationClaimId));
        }

        public IDataResult<List<UserOperationClaim>> GetUserOperationClaimsByUserId(int userId)
        {
            IResult result = BusinessRules.Run(CheckIfUserOperationClaimNull(userId));
            if (result != null)
            {
                return new ErrorDataResult<List<UserOperationClaim>>(result.Message);
            }
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(i => i.UserId == userId));
        }
        private IResult CheckIfUserOperationClaimNull(int userOperationClaimId)
        {
            if (_userOperationClaimDal.GetAll().Any(x => x.UserOperationClaimId == userOperationClaimId))
            {
                return new ErrorResult("User Operation Claim Exist");
            }
            return new SuccessResult();
        }
    }
}