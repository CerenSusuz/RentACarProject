using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDAL.Add(car);
            return new SuccessResult();

        }

        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDAL.Delete(car);
            return new SuccessResult();
        }

        [SecuredOperation("car.update,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDAL.Update(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 06)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDAL.Get(c => c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetails(c => c.BrandId == brandId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetails(c => c.ColorId == colorId));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetails());
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetail(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetails(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColor(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDAL.GetCarDetails(c => c.ColorId == colorId & c.BrandId == brandId));
        }
    }
}