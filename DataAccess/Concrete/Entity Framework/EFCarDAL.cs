using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in filter is null ? context.Cars : context.Cars.Where(filter)
                             
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };

                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetailsViaId(int carId)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from car in context.Cars.Where(car => car.Id == carId)

                    join color in context.Colors
                     on car.ColorId equals color.ColorId

                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId

                    select new CarDetailDto
                    {
                        Id = car.Id,
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        DailyPrice = car.DailyPrice,
                        Description = car.Description,
                        ModelYear = car.ModelYear
                        
                    };
                return result.SingleOrDefault();
            }
        }
    }
}
