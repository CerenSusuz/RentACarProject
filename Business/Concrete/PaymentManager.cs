using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        //testing

        public IResult MakePayment(PaymentTest payment)
        {
            if (payment.Amount < 100)
            {
                if (payment.SecurityCode == "111")
                {
                    return new ErrorResult("PaymentCardError");
                }
            }
            return new SuccessResult();
        }
    }
}
