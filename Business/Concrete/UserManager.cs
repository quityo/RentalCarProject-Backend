using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
          ValidationTool.Validate(new UserValidator(),user);

                _userDal.Add(user);
                {
                    return new SuccessResult(Messages.Added);
                }
        }
        public IResult Update(User user)
        {
            if (!user.Email.Contains("@"))
            {
                return new ErrorResult("Email Adresinizi Kontrol Edin.");
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.Updated);
        }
        public IResult Delete(User user)
        {
            try
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception)
            {

                throw new Exception("Sistem Hatası! Silinme İşlemi Gerçekleşmedi.");
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.GetAll);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(p=>p.UserId == userId), Messages.GetUserByUserId);
        }

        
    }
}
