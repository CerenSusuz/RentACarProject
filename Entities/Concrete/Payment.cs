using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Payment : IEntity
    {
        public decimal Amount { get; set; }
    }
}