using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Concrete.Entity_Framework.Context;
using Entities.DTOs;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFCustomerDAL : EFEntityRepositoryBase<Customer,ReCapDbContext>, ICustomerDAL
    {
        public List<CustomerDetailDto> GetCustomerDetailDto()
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from customer in context.Customers
                    join user in context.Users on customer.UserId equals user.Id
                    select new CustomerDetailDto()
                    {
                        CustomerId = customer.Id,
                        CompanyName = customer.CompanyName,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                return result.ToList();
            }
        }
    }
}
