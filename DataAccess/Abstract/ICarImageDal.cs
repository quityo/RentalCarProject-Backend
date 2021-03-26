using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
    }
}
