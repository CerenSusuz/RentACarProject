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
        ICustomerService _customerService;

        public RentalManager(IRentalDAL rentalDAL, ICarDAL carDAL, ICustomerService customerService)
        {
            _rentalDAL = rentalDAL;
            _carDAL = carDAL;
            _customerService = customerService;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("rental.add,admin,user")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckCarAvailable(rental),
                CheckCreditScoreByCustomer(rental.CustomerID,rental.CarID));

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
            || (r.RentEndDate >= rental.RentBeginDate && r.RentBeginDate >= rental.RentBeginDate)
            || (r.RentEndDate >= rental.RentEndDate && r.RentBeginDate >= rental.RentEndDate)
            || (r.RentBeginDate >= rental.RentBeginDate && r.RentEndDate >= rental.RentEndDate));

            if (result != null)
            {
                return new ErrorResult(Messages.NotCarAvailable);
            }

            return new SuccessResult();
        }

        private IResult CheckCreditScoreByCustomer(int customerId, int carId)
        {
            var car = _carDAL.Get(c => c.Id == carId);

            var customerScore = _customerService.CalculateScore(customerId);
            var carScore = car.MinFindexScore;

            if (customerScore.Data >= carScore)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotEnough);

        }

    }
}


