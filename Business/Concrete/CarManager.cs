using Business.Abstract;
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
    public class CarManager : ICarService
    {
        ICarDAL _carDAL;
        public CarManager(ICarDAL carDAL)
        {
            _carDAL = carDAL;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice < 0)
            {
                Console.WriteLine("Enter the daily price of the car at a greater value than zero.");
                return new ErrorResult();
            }
            _carDAL.Add(car);
            return new SuccessResult(Messages.Added);

        }
        public IResult Delete(Car car)
        {
            _carDAL.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }
        public IResult Update(Car car)
        {
            _carDAL.Update(car);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(),Messages.Listed);
        }
        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.Listed);
        }
        public IDataResult<Car> GetById(Car car)
        {
            return new SuccessDataResult<Car>(_carDAL.Get(c => c.Id == car.Id));
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.BrandId == id));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDAL.GetAll(c => c.ColorId == id));
        }
    }
}
