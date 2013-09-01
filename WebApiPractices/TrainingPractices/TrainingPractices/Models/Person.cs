using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingPractices.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsMarried { get; set; }

        private static IList<Person> all;
        public static IList<Person> All
        {
            get
            {
                if (all==null)
                {
                    all = new List<Person>()
                    {
                        new Person(){Id=10001,FirstName="Alfred",LastName="Nobel",Address="Kentucky",PhoneNumber="01-123456780",IsMarried=true},
                        new Person(){Id=10002,FirstName="Robert",LastName="Gonzalas",Address="Texas",PhoneNumber="01-345678934",IsMarried=false},
                        new Person(){Id=10003,FirstName="Albert",LastName="Einstein",Address="Switzerland",PhoneNumber="034-56783406",IsMarried=false},
                        new Person(){Id=10004,FirstName="Charles",LastName="Babbage",Address="London",PhoneNumber="012-456783076",IsMarried=true}

                    };
                }

                return all;
            }
            set
            {
                all = value;
            }
        }
    }
}