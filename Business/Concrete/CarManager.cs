using Business.Abstract;
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
        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDAL.Add(car);
            }
            else
            {
                Console.WriteLine("Enter the daily price of the car at a greater value than zero.");
            }
        }
        public List<Car> GetAll()
        {
            return _carDAL.GetAll();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDAL.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public Car GetById(Car car)
        {
            return _carDAL.Get(c => c.Id == car.Id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDAL.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDAL.GetAll(c => c.ColorId == id);
        }
    }
}
