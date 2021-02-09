using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDAL : ICarDAL
    {
        List<Car> _cars;
        public InMemoryCarDAL()
        {
            _cars = new List<Car>
            {
                new Car { Id= 1,BrandId=1,ColorId=1,DailyPrice=100000,Description="fast, super model",ModelYear=2020},
                new Car { Id= 2,BrandId=2,ColorId=2,DailyPrice=150000,Description="fast",ModelYear=2010},
                new Car { Id= 3,BrandId=2,ColorId=3,DailyPrice=300000,Description="fast, super model",ModelYear=2019},
                new Car { Id= 4,BrandId=1,ColorId=1,DailyPrice=200000,Description="fast, super model",ModelYear=2010}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(Car car)
        {
           return _cars.SingleOrDefault(c => c.Id == car.Id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            car.BrandId = 3;
            car.ColorId = 4;
            car.DailyPrice = 123456;
            car.Description = "super fast";
            car.ModelYear = 2016;
        }
    }
}
