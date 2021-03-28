using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult MakePayment(Payment payment);
    }
}
