using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalMVCTest.Models
{
    public interface IPersonService
    {
        IList<Person> GetAll();

    }

    public class PersonService:IPersonService
    {

        public IList<Person> GetAll()
        {
            return new List<Person> { new Person() { Name = "Person 1" }, new Person() { Name = "Person 2" } };

        }
    }
}
