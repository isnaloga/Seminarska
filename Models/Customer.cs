using System;
using System.Collections.Generic;

namespace IS_nal.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int PlanID { get; set; }
        public Plan Plan { get; set; }
    }

}