using Core.DataAccess.EntityFramework;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Concrete.Entity_Framework.Context;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFRentalDAL : EFEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDAL
    {
        public List<RentalDetailDto> GetRentalsDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from rental in context.Rentals

                             join car in context.Cars
                             on rental.CarID equals car.Id

                             join customer in context.Customers
                             on rental.CustomerID equals customer.Id

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             join user in context.Users
                             on customer.UserId equals user.Id

                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 CarID = car.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 CompanyName = customer.CompanyName,
                                 UserName = user.FirstName + " " + user.LastName,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 RentDate = rental.RentDate,
                                 DailyPrice = car.DailyPrice,
                                 ReturnDate = rental.ReturnDate
                             };

                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public RentalDetailDto GetRentalDetails(int id)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from rental in context.Rentals.Where(r => r.Id == id)

                    join car in context.Cars
                        on rental.CarID equals car.Id

                    join customer in context.Customers
                        on rental.CustomerID equals customer.Id

                    join brand in context.Brands
                        on car.BrandId equals brand.BrandId

                    join color in context.Colors
                        on car.ColorId equals color.ColorId

                    join user in context.Users
                        on customer.UserId equals user.Id

                        select new RentalDetailDto
                    {
                        Id = rental.Id,
                        CarID = car.Id,
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        CompanyName = customer.CompanyName,
                        UserName = user.FirstName + " " + user.LastName,
                        Description = car.Description,
                        ModelYear = car.ModelYear,
                        RentDate = rental.RentDate,
                        DailyPrice = car.DailyPrice,
                        ReturnDate = rental.ReturnDate
                    };

                return result.SingleOrDefault();
            }
        }
    }
}
