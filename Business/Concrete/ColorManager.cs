using Business.Abstract;
using Business.BusinessAspect.Autofac;
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

        [SecuredOperation("color.add,admin")]
        public IResult Add(Color color)
        {
            _colorDAL.Add(color);
            return new SuccessResult();
        }

        [SecuredOperation("color.delete,admin")]
        public IResult Delete(Color color)
        {
            _colorDAL.Delete(color);
            return new SuccessResult();
        }

        [SecuredOperation("color.update,admin")]
        public IResult Update(Color color)
        {
            _colorDAL.Update(color);
            return new SuccessResult();
        }
        public IDataResult<List<Color>> GetColors()
        {
            return new SuccessDataResult<List<Color>>(_colorDAL.GetAll());
        }
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDAL.Get(c => c.Id == id));
        }

    }
}
