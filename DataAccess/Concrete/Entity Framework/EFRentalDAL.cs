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

                             join user in context.Users
                             on customer.UserId equals user.Id

                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 CarID = car.Id,
                                 UserName = user.FirstName + " " + user.LastName,
                                 CompanyName = customer.CompanyName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
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

                    join user in context.Users
                        on customer.UserId equals user.Id

                        select new RentalDetailDto
                    {
                        Id = rental.Id,
                        CarID = car.Id,
                        UserName = user.FirstName + " " + user.LastName,
                        CompanyName = customer.CompanyName,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    };

                return result.SingleOrDefault();
            }
        }
    }
}
