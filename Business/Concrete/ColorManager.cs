using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager
    {
        IColorDAL _colorDAL;
        public ColorManager(IColorDAL colorDAL)
        {
            _colorDAL = colorDAL;
        }
        public void Add(Color color)
        {
            _colorDAL.Add(color);
        }

        public void Delete(Color color)
        {
            _colorDAL.Delete(color);
        }

        public List<Color> GetColors()
        {
            return _colorDAL.GetAll();
        }

        public Color GetById(Color color)
        {
            return _colorDAL.Get(c => c.Id == color.Id);
        }

        public void Update(Color color)
        {
            _colorDAL.Update(color);
        }
    }
}
