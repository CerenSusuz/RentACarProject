using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class PaymentTest : IEntity
    {
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public Rental Rental { get; set; }
    }
}