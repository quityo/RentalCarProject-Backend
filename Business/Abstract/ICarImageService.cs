using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult DeleteByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int imageId);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IResult Add(CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);
        
    }
}
