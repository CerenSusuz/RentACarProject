using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CarDetailsViaImagesDto : IDto
    {
        public CarDetailDto CarDetail { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
