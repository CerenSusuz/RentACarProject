using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class RentalPaymentDto
    {
        public Rental Rental { get; set; }
        public Payment Payment { get; set; }
    }
}
