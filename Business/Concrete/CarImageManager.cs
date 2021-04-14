using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        //[ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImagesDto carImagesDto)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImagesDto.CarId));
            if (result != null) return result;
            CarImage carimage = new CarImage
            {
                CarId = carImagesDto.CarId,
                ImagePath = FileHelper.SaveImageFile(carImagesDto.ImageFile),
                Date = DateTime.Now
            };
            _carImageDal.Add(carimage);
            return new SuccessResult(Messages.CarImageAdded);
        }
        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count < 5;
            if (!result) return new ErrorResult(Messages.CarImageCountExceeded);
            return new SuccessResult();
        }
        public IResult Update(CarImagesDto carImagesDto)
        {
            var result = _carImageDal.Get(ci => ci.ImageId == carImagesDto.ImageId);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.Delete(result.ImagePath);
            result.ImagePath = FileHelper.SaveImageFile(carImagesDto.ImageFile);
            result.Date = DateTime.Now;
            _carImageDal.Update(result);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        //[ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImagesDto carImagesDto)
        {
            var result = _carImageDal.Get(ci => ci.ImageId == carImagesDto.ImageId);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.Delete(result.ImagePath);
            _carImageDal.Delete(result);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        //[ValidationAspect(typeof(CarImageValidator))]

        public IDataResult<CarImage> Get(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.ImageId == imageId));

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId), "listelendi");
        }
        //[ValidationAspect(typeof(CarImageValidator))]
        //[CacheRemoveAspect("ICarImageService.Get")]
       
        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int imageId)
        {
            string path = @"\images\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == imageId).Any();
            if (!result)
            {
                return new List<CarImage>
                {
                    new CarImage
                    {
                        CarId = imageId,
                        ImagePath = path,
                        Date = DateTime.Now
                    }
                };
            }
            return _carImageDal.GetAll(c => c.CarId == imageId);
        }
        public IResult DeleteByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            foreach (var item in result)
            {
                FileHelper.Delete(item.ImagePath);
                _carImageDal.Delete(item);
            }
            return new SuccessResult(Messages.CarImagesDeleted);
        }
    }
}