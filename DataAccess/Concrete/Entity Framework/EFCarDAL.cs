using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Concrete.Entity_Framework.Context;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFCarDAL : EFEntityRepositoryBase<Car, ReCapDbContext>, ICarDAL
    {
        public List<CarDetailDto> GetCarsDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars 

                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             select new CarDetailDto()
                             {
                                 Id = car.Id,
                                 Description = car.Description,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.Name,
                                 ColorId = color.ColorId,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 MinFindexScore = car.MinFindexScore
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public CarDetailDto GetCarDetails(int carId)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars.Where(c => c.Id == carId)

                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             select new CarDetailDto()
                             {
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 Id = car.Id,
                                 MinFindexScore = car.MinFindexScore
                             };
                       
                return result.SingleOrDefault();
            }
        }
    }
}
