using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Concrete.Entity_Framework.Context;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EFBrandDAL : EFEntityRepositoryBase<Brand,ReCapDbContext>, IBrandDAL
    {
        
    }
}
