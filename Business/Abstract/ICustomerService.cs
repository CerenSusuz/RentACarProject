﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<List<Customer>> GetCustomers();
        IDataResult<Customer> GetById(int id);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IDataResult<int> CalculateScore(int id);
    }
}
