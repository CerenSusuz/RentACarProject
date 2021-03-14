using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDAL _colorDAL;
        public ColorManager(IColorDAL colorDAL)
        {
            _colorDAL = colorDAL;
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.add,admin")]
        public IResult Add(Color color)
        {
            _colorDAL.Add(color);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.delete,admin")]
        public IResult Delete(Color color)
        {
            _colorDAL.Delete(color);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("color.update,admin")]
        public IResult Update(Color color)
        {
            _colorDAL.Update(color);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetColors()
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDAL.Get(c => c.ColorId == id));
        }

    }
}
