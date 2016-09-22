using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LittleSheep.Entities
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }
        public string Town { get; set; }
        public string Password { get; set; }
    }
}