using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using DataAccess.Abstract;
using System.Linq;
using Business.Abstract;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {

        IUserImageDal _userImageDal;
        public UserImageManager(IUserImageDal userImageDal)
    {
        _userImageDal = userImageDal;
    }
    //[ValidationAspect(typeof(CarImageValidator))]
    //[CacheRemoveAspect("ICarImageService.Get")]
    public IResult Add(UserImageDto userImagesDto)
    {
        var result = BusinessRules.Run(CheckUserImagesCount(userImagesDto.UserId));
        if (result != null) return result;
        UserImage userImage = new UserImage
        {
            UserId = userImagesDto.UserId,
            ImagePath = FileHelper.SaveImageFile(userImagesDto.ImageFile),
            Date = DateTime.Now
        };
        _userImageDal.Add(userImage);
        return new SuccessResult(Messages.CarImageAdded);
    }
    private IResult CheckUserImagesCount(int userId)
    {
        var result = _userImageDal.GetAll(ci => ci.UserId == userId).Count < 5;
        if (!result) return new ErrorResult(Messages.CarImageCountExceeded);
        return new SuccessResult();
    }
    public IResult Update(UserImageDto userImagesDto)
    {
        var result = _userImageDal.Get(ci => ci.ImageId == userImagesDto.ImageId);
        if (result == null) return new ErrorResult(Messages.CarImageNotFound);
        FileHelper.Delete(result.ImagePath);
        result.ImagePath = FileHelper.SaveImageFile(userImagesDto.ImageFile);
        result.Date = DateTime.Now;
        _userImageDal.Update(result);
        return new SuccessResult(Messages.CarImageUpdated);
    }
    //[ValidationAspect(typeof(CarImageValidator))]
    //[CacheRemoveAspect("ICarImageService.Get")]
    public IResult Delete(UserImageDto userImagesDto)
    {
        var result = _userImageDal.Get(ci => ci.ImageId == userImagesDto.ImageId);
        if (result == null) return new ErrorResult(Messages.CarImageNotFound);
        FileHelper.Delete(result.ImagePath);
        _userImageDal.Delete(result);
        return new SuccessResult(Messages.CarImageDeleted);
    }
    //[ValidationAspect(typeof(CarImageValidator))]

    public IDataResult<UserImage> Get(int imageId)
    {
        return new SuccessDataResult<UserImage>(_userImageDal.Get(c => c.ImageId == imageId));

    }

    public IDataResult<List<UserImage>> GetAll()
    {
        return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll());
    }

    public IDataResult<List<UserImage>> GetImagesByUserId(int userId)
    {
        return new SuccessDataResult<List<UserImage>>(CheckIfUserImageNull(userId), "listelendi");
    }
    //[ValidationAspect(typeof(CarImageValidator))]
    //[CacheRemoveAspect("ICarImageService.Get")]

    private IResult CheckImageLimitExceeded(int userId)
    {
        var carImageCount = _userImageDal.GetAll(c => c.UserId == userId).Count;
        if (carImageCount >= 2)
        {
            return new ErrorResult(Messages.CarImageLimitExceeded);
        }
        return new SuccessResult();
    }
    private List<UserImage> CheckIfUserImageNull(int imageId)
    {
        string path = @"\images\default.jpg";
        var result = _userImageDal.GetAll(c => c.UserId == imageId).Any();
        if (!result)
        {
            return new List<UserImage>
                {
                    new UserImage
                    {
                        UserId = imageId,
                        ImagePath = path,
                        Date = DateTime.Now
                    }
                };
        }
        return _userImageDal.GetAll(c => c.UserId == imageId);
    }
    public IResult DeleteByUserId(int userId)
    {
        var result = _userImageDal.GetAll(ci => ci.UserId == userId);
        foreach (var item in result)
        {
            FileHelper.Delete(item.ImagePath);
            _userImageDal.Delete(item);
        }
        return new SuccessResult(Messages.CarImagesDeleted);
    }
}
}