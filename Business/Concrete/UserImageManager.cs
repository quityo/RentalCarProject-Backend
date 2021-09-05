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
        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]
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
            return new SuccessResult("User Image Added");
        }
        private IResult CheckUserImagesCount(int userId)
        {
            var result = _userImageDal.GetAll(ci => ci.UserId == userId).Count <2;
            if (!result) return new ErrorResult("User Image Count Exceeded");
            return new SuccessResult();
        }
        public IResult Update(UserImageDto userImagesDto)
        {
            var result = _userImageDal.Get(ci => ci.ImageId == userImagesDto.ImageId);
            if (result == null) return new ErrorResult("User Image Not Found");
            FileHelper.Delete(result.ImagePath);
            result.ImagePath = FileHelper.SaveImageFile(userImagesDto.ImageFile);
            result.Date = DateTime.Now;
            _userImageDal.Update(result);
            return new SuccessResult("User Image Updated");
        }
        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]
        public IResult Delete(UserImageDto userImagesDto)
        {
            var result = _userImageDal.Get(ci => ci.ImageId == userImagesDto.ImageId);
            if (result == null) return new ErrorResult("User Image Not Found");
            FileHelper.Delete(result.ImagePath);
            _userImageDal.Delete(result);
            return new SuccessResult("User Image Not Deleted");
        }
        //[ValidationAspect(typeof(UserImageValidator))]

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
            IResult result = BusinessRules.Run(CheckIfUserImageNull(userId));
            if (result != null)
            {
                return new ErrorDataResult<List<UserImage>>(result.Message);
            }
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(i => i.UserId == userId));
        }
        //[ValidationAspect(typeof(UserImageValidator))]
        //[CacheRemoveAspect("IUserImageService.Get")]

        private IResult CheckImageLimitExceeded(int userId)
        {
            var userImageCount = _userImageDal.GetAll(c => c.UserId == userId).Count;
            if (userImageCount >1)
            {
                return new ErrorResult("User Image Limit Exceeded");
            }
            return new SuccessResult();
        }
        private IDataResult<List<UserImage>> CheckIfUserImageNull(int imageId)
        {
            try
            {
                string path = @"\wwwroot\images\crop.jpg";
            var result = _userImageDal.GetAll(c => c.UserId == imageId).Any();
            if (!result)
            {
                    List<UserImage> images = new List<UserImage>();


                    images.Add(new UserImage() { UserId = imageId, Date = DateTime.Now, ImagePath = path });
                    return new SuccessDataResult<List<UserImage>>(images);
                }

            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<UserImage>>(e.Message);
            }

            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(i => i.UserId == imageId));
        }
        public IResult DeleteByUserId(int userId)
        {
            var result = _userImageDal.GetAll(ci => ci.UserId == userId);
            foreach (var item in result)
            {
                FileHelper.Delete(item.ImagePath);
                _userImageDal.Delete(item);
            }
            return new SuccessResult("User Images Deleted");
        }
    }
}