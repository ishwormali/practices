using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProfessionalMVCTest.Models
{
    public class Person:IValidatableObject
    {
        [Required]
        [NoSpace]
        
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public int Age { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield return ValidationResult.Success;
            //yield return new ValidationResult ("Validation failed on something",new List<string>{"FirstName","LastName"});
            
        }
    }

    public class Address
    {
      [Required()]
        public string StreetAddress { get; set; }
        public string City { get; set; }
    }
}