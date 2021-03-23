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
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
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
                                 Status = !context.Rentals.Any(r=>r.CarID == car.Id && r.ReturnDate == null)
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

    }
}
