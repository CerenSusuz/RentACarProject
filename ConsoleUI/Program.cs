using Business.Concrete;
using DataAccess.Concrete.Entity_Framework;
//using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDAL());
            BrandManager brandManager = new BrandManager(new EFBrandDAL());
            ColorManager colorManager = new ColorManager(new EFColorDAL());

            // AddCar(carManager);

            // GetDailyPrice(carManager);

            // GetColors(colorManager);

        }

        private static void GetColors(ColorManager colorManager)
        {
            foreach (Color color in colorManager.GetColors())
            {
                Console.WriteLine(color.Name);

            }
        }

        private static void AddCar(CarManager carManager)
        {
            Car car = new Car
            {
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 200,
                Description = "New Model",
                ModelYear = 2021,
            };
            carManager.Add(car);
        }

        private static void GetDailyPrice(CarManager carManager)
        {
            foreach (var car in carManager.GetByDailyPrice(750, 1000))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
