using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProfilImageManager : IProfilImageService
    {
        IProfilImageDal _profilImageDal;
        public ProfilImageManager(IProfilImageDal profilImageDal)
        {
            _profilImageDal = profilImageDal;
        }
            //[ValidationAspect(typeof(CarImageValidator))]
            //[CacheRemoveAspect("ICarImageService.Get")]
            public IResult Add(ProfilImagesDto profilImagesDto)
        {
            var result = BusinessRules.Run(CheckProfilImagesCount(profilImagesDto.UserId));
            if (result != null) return result;
            ProfilImage profilImage = new ProfilImage
            {
                UserId = profilImagesDto.UserId,
                ProfilImagePath = FileHelper.SaveImageFile(profilImagesDto.ImageFile),
                Date = DateTime.Now
            };
            _profilImageDal.Add(profilImage);
            return new SuccessResult(Messages.CarImageAdded);
        }
        private IResult CheckProfilImagesCount(int userId)
        {
            var result = _profilImageDal.GetAll(u => u.UserId == userId).Count < 5;
            if (!result) return new ErrorResult(Messages.CarImageCountExceeded);
            return new SuccessResult();
        }
        public IResult Update(ProfilImagesDto profilImagesDto)
        {
            var result = _profilImageDal.Get(ci => ci.ProfilImageId == profilImagesDto.ProfilImageId);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.Delete(result.ProfilImagePath);
            result.ProfilImagePath = FileHelper.SaveImageFile(profilImagesDto.ImageFile);
            result.Date = DateTime.Now;
            _profilImageDal.Update(result);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        //[ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(ProfilImagesDto profilImagesDto)
        {
            var result = _profilImageDal.Get(ci => ci.ProfilImageId == profilImagesDto.ProfilImageId);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.Delete(result.ProfilImagePath);
            _profilImageDal.Delete(result);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        //[ValidationAspect(typeof(CarImageValidator))]

        public IDataResult<ProfilImage> Get(int profilImageId)
        {
            return new SuccessDataResult<ProfilImage>(_profilImageDal.Get(c => c.ProfilImageId == profilImageId));

        }

        public IDataResult<List<ProfilImage>> GetAll()
        {
            return new SuccessDataResult<List<ProfilImage>>(_profilImageDal.GetAll());
        }

        public IDataResult<List<ProfilImage>> GetImagesByUserId(int userId)
        {
            return new SuccessDataResult<List<ProfilImage>>(CheckIfProfilImageNull(userId), "listelendi");
        }
        //[ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]

        private IResult CheckImageLimitExceeded(int userId)
        {
            var profilImageCount = _profilImageDal.GetAll(c => c.UserId == userId).Count;
            if (profilImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private List<ProfilImage> CheckIfProfilImageNull(int profilImageId)
        {
            string path = @"\images\default.jpg";
            var result = _profilImageDal.GetAll(c => c.UserId == profilImageId).Any();
            if (!result)
            {
                return new List<ProfilImage>
                {
                    new ProfilImage
                    {
                        UserId = profilImageId,
                        ProfilImagePath = path,
                        Date = DateTime.Now
                    }
                };
            }
            return _profilImageDal.GetAll(c => c.UserId == profilImageId);
        }
        public IResult DeleteByUserId(int userId)
        {
            var result = _profilImageDal.GetAll(ci => ci.UserId == userId);
            foreach (var item in result)
            {
                FileHelper.Delete(item.ProfilImagePath);
                _profilImageDal.Delete(item);
            }
            return new SuccessResult(Messages.CarImagesDeleted);
        }

        
    }
}
