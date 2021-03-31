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
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDAL _rentalDAL;
        ICarDAL _carDAL; 
        ICustomerDAL _customerDAL;

        public RentalManager(IRentalDAL rentalDAL, ICarDAL carDAL, ICustomerDAL customerDAL)
        {
            _rentalDAL = rentalDAL;
            _carDAL = carDAL;
            _customerDAL = customerDAL;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("rental.add,admin,user")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckCarAvailable(rental),
                CheckFindexScoreByCustomer(rental.CustomerID,rental.CarID));

            if (result != null)
            {
               return result;
            }
            
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
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDAL.Get(r => r.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDAL.GetRentalsDetails());
        }

        [CacheAspect]
        public IDataResult<RentalDetailDto> GetRentalDetailsById(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDAL.GetRentalDetails(id));
        }

        private IResult CheckCarAvailable(Rental rental)
        {
            var result =
                _rentalDAL.Get(r => (r.CarID == rental.CarID && r.ReturnDate == null) 
            || (r.RentDate >= rental.RentDate && r.ReturnDate >= rental.RentDate));

            if (result != null)
            {
                return new ErrorResult(Messages.NotCarAvailable);
            }

            return new SuccessResult();
        }

        private IResult CheckFindexScoreByCustomer(int customerId, int carId)
        {
            var car = _carDAL.Get(c => c.Id == carId);

            var customer = _customerDAL.Get(c => c.Id == customerId);

            var carScore = car.MinFindexScore;
            var customerScore = customer.FindexScore;

            if (customerScore >= carScore)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotEnough);

        }

    }
}


