using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo2.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string RegistrationDate { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public string[] Hobbies { get; set; }

    }
}