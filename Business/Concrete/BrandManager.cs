using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDAL _brandDAL;
        public BrandManager(IBrandDAL brandDal)
        {
            _brandDAL = brandDal;
        }
        public void Add(Brand brand)
        {
            _brandDAL.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDAL.Delete(brand);
        }

        public List<Brand> GetBrands()
        {
            return _brandDAL.GetAll();
        }

        public Brand GetById(Brand brand)
        {
            return _brandDAL.Get(b => b.Id == brand.Id);
        }

        public void Update(Brand brand)
        {
            _brandDAL.Update(brand);
        }
    }
}
