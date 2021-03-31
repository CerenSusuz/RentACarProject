using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.DTOs
{
    public class UserForUpdateDto :IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
