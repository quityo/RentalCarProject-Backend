using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Entities.DTOs;
using Core.Aspects.AutoFac.Cancelation;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [SecuredOperation("carimage.add")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CancellationTokenAspect]
        public IResult Add(CarImageDto carImagesDto)
        {
            var result = BusinessRules.Run(CheckCarImagesCount(carImagesDto.CarId));
            if (result != null) return result;
            CarImage carimage = new CarImage
            {
                CarId = carImagesDto.CarId,
                ImagePath = FileHelper.SaveImageFile(carImagesDto.ImageFile),
                Created = DateTime.Now
            };
            _carImageDal.Add(carimage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carimage.update")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImageDto carImagesDto)
        {
            var result = _carImageDal.Get(ci => ci.ImageId == carImagesDto.ImageId);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.DeleteImageFile(result.ImagePath);
            result.ImagePath = FileHelper.SaveImageFile(carImagesDto.ImageFile);
            result.Created = DateTime.Now;
            _carImageDal.Update(result);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        [SecuredOperation("carimage.delete")]
        public IResult Delete(CarImageDto carImagesDto)
        {
            var result = _carImageDal.Get(ci => ci.ImageId == carImagesDto.ImageId);
            if (result == null) return new ErrorResult(Messages.CarImageNotFound);
            FileHelper.DeleteImageFile(result.ImagePath);
            _carImageDal.Delete(result);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count < 5;
            if (!result) return new ErrorResult(Messages.CarImageCountExceeded);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            CarImage result = _carImageDal.Get(ci => ci.ImageId == imageId);
            if (result == null) return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            return new SuccessDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Any()) return new SuccessDataResult<List<CarImage>>(result);
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
            {
                new CarImage{  CarId = carId,  ImagePath = "default.jpg", Created  = DateTime.Now }
            });
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IResult DeleteByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            foreach (var item in result)
            {
                FileHelper.DeleteImageFile(item.ImagePath);
                _carImageDal.Delete(item);
            }
            return new SuccessResult(Messages.CarImagesDeleted);
        }
    }
}