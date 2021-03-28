using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entity_Framework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFCreditCardDAL :EFEntityRepositoryBase<CreditCard, ReCapDbContext>, ICreditCardDAL
    {
    }
}
