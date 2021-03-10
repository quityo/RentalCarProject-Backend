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
        //veritabanın soyut sınıfına erişeceğiz.
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]//s1
        [SecuredOperation("color.add, admin")] //s2
        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.ColorCanNotAdded);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }


        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(co => co.ColorId == colorId));
        }

        

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Updated);
        }
    }
}

