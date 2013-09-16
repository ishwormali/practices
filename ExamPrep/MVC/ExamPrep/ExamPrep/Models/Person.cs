using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    var nameArr = value.Split(' ');
                    FirstName = nameArr[0];
                    if (nameArr.Length > 1)
                    {
                        LastName = nameArr[1];
                    }
                }
            }
        }
    }
}