using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDAL.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDAL.Add(user);
            
        }

        public User GetByMail(string email)
        {
            return _userDAL.Get(u => u.Email == email);
        }
    }
}



