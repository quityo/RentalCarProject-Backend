using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal colorDal)
        { 
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        //[SecuredOperation("color.add, admin")]
        public IResult Add(Color color)
        {
            
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }
        [ValidationAspect(typeof(ColorValidator))]
        //[SecuredOperation("color.update, admin")]
        public IResult Update(Color color)
        {
            
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
        [ValidationAspect(typeof(ColorValidator))]
        //[SecuredOperation("color.delete, admin")]
        public IResult Delete(Color color)
        {
            
                _colorDal.Delete(color);
                return new SuccessResult(Messages.Deleted);
           
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.GetAll);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == colorId), Messages.GetColorByColorId);
        }

        public IDataResult<List<Color>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p => p.ColorId == colorId));
        }
    }
}

