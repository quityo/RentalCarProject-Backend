using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<T>
    {
        IResult Add(T t);
        IResult Update(T t);
        IResult Delete(T t);
        IDataResult<List<T>> GetAll();

        IDataResult<T> GetById(int id);

        
    }
}
