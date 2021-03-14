using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }

}
