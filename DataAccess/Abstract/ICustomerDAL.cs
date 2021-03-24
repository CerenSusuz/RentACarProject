using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerDAL : IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetCustomerDetailDto();
    }
}
