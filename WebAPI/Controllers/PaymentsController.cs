using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        //for test

        [HttpGet("makepayment")]
        public IActionResult MakePayment(Payment payment) 
        {
            var result = _paymentService.MakePayment(payment);
            if (result.Success) return Ok(result);

            return BadRequest(result);
        }
    }
}
