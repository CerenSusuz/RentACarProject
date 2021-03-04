using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        [SecuredOperation("brand.add,admin")]
        public IResult Add(Brand brand)
        {
            _brandDAL.Add(brand);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("brand.delete,admin")]
        public IResult Delete(Brand brand)
        {
            _brandDAL.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("brand.update,admin")]
        public IResult Update(Brand brand)
        {
            _brandDAL.Update(brand);
            return new SuccessResult(Messages.Updated);
        }
        
        public IDataResult<List<Brand>> GetBrands()
        {
            return new SuccessDataResult<List<Brand>>(_brandDAL.GetAll());
        }
        
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDAL.Get(b => b.Id == id));
        }

    }
}
