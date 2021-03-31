using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDAL _userDAL;

        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDAL.Get(u => u.Id == userId));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDAL.GetClaims(user));
        }

        public IResult Add(User user)
        {
            _userDAL.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDAL.Update(user);
            return new SuccessResult();

        }

        public IResult EditProfile(UserForUpdateDto user)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            
            HashingHelper.CreatePasswordHash(user.Password, out passwordHash,out passwordSalt);

            var userInfo = new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email= user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userDAL.Update(userInfo);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDAL.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetAll());
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDAL.Get(u => u.Email == email));
        }
    }
}

