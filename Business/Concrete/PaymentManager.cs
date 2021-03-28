using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        //testing

        public IResult MakePayment(Payment payment)
        {
            if (payment.Amount < 100)
            {
                return new ErrorResult("Payment Error");
            }
            return new SuccessResult();
        }
    }
}
