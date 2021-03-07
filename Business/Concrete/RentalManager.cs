using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDAL _rentalDAL;
        public RentalManager(IRentalDAL rentalDAL)
        {
            _rentalDAL = rentalDAL;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("rental.add,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDAL.Add(rental);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("rental.delete,admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDAL.Delete(rental);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("rental.update,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDAL.Update(rental);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetRentals()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDAL.Get(r => r.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == 06)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDAL.GetRentalDetails());
        }
    }
} 


