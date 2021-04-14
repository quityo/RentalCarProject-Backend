using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace Business.Abstract
{

    public interface ICarImageService
    {
        IResult Add(CarImagesDto carImage);
        IResult Update(CarImagesDto carImage);
        IResult Delete(CarImagesDto carImage);
        IDataResult<CarImage> Get(int imageId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IResult DeleteByCarId(int carId);
    }
}
