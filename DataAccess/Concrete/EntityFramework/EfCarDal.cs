using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{

	public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
	{
		public List<CarDetailDto> GetCarDetail()
		{
			using (RentACarContext context = new RentACarContext())
			{
				var result = from c in context.Car
							 join b in context.Brand
							 on c.BrandId equals b.BrandId
							 join col in context.Color
							 on c.ColorId equals col.ColorId
							 select new CarDetailDto
							 {
								 CarId = c.CarId,
								 CarName = c.CarName,
								 BrandName = b.BrandName,
								 ColorName = col.ColorName,
								 ModelYear = c.ModelYear,
								 DailyPrice = c.DailyPrice,
								 Description = c.Description
							 };
				return result.ToList();
			}
		}
		public List<CarDetailDto> GetByBrandDetails(int brandId)
		{
			using (RentACarContext context = new RentACarContext())
			{
				var result = from c in context.Car
							 where c.BrandId == brandId
							 join b in context.Brand
							 on c.BrandId equals b.BrandId
							 join co in context.Color
							 on c.ColorId equals co.ColorId
							 select new CarDetailDto
							 {
								 CarId = c.CarId,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 DailyPrice = c.DailyPrice
							 };
				return result.ToList();
			}
		}

		public List<CarDetailDto> GetByColorDetails(int colorId)
		{
			using (RentACarContext context = new RentACarContext())
			{
				var result = from c in context.Car
							 where c.ColorId == colorId
							 join b in context.Brand
							 on c.BrandId equals b.BrandId
							 join co in context.Color
							 on c.ColorId equals co.ColorId
							 select new CarDetailDto
							 {
								 CarId = c.CarId,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 DailyPrice = c.DailyPrice
							 };
				return result.ToList();
			}
		}
	}
}