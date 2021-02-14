using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int RentalID { get; set; }
        public string CarName { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
