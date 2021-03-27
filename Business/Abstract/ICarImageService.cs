using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface ICarImageService
    {
		IDataResult<List<CarImage>> GetAll();
		IDataResult<List<CarImage>> GetImagesByCarId(int carId);
		IDataResult<CarImage> Get(int imageId);
		IResult Add(IFormFile file, CarImage carImage);
		IResult Update(IFormFile file, CarImage carImage);
		IResult Delete(CarImage carImage);
	}
}
