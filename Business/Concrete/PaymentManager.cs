using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult MakePayment(Payment payment)
        {
            if (payment.Amount > 8000)
            {
                return new ErrorResult("test");
            }
            return new SuccessResult();
        }
    }
}
