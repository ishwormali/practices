using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrainingPractices.Models;

namespace TrainingPractices.Controllers
{
    public class PersonController : ApiController
    {
        
        // GET api/person
        public IEnumerable<Person> Get()
        {
            return Person.All;
        }

        // GET api/person/5
        public Person Get(int id)
        {
            var person=Person.All.FirstOrDefault(m=>m.Id.Equals(id));
            if (person==null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Person with id {0} not found", id)));
                
            }

            return person;
        }

        // PUT api/person/5
        public HttpResponseMessage POST(Person person,string someParam)
        {
            person.Id = Person.All.Max(m => m.Id) + 1;
            Person.All.Add(person);
            return Request.CreateResponse(HttpStatusCode.OK, person);
            
            //return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/person/5
        //[HttpPost]
        public HttpResponseMessage Delete(int Id)
        {
            var person = Person.All.FirstOrDefault(m => m.Id.Equals(Id));
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Person with id {0} not found", Id)));

            }

            Person.All.Remove(person);
            return Request.CreateResponse(HttpStatusCode.OK, string.Format("Successfully deleted {0} from the system.", person.FirstName));

        }

        // POST api/person
        public HttpResponseMessage Put(Person person)
        {
            var p = Person.All.FirstOrDefault(m => m.Id == person.Id);
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.IsMarried = person.IsMarried;
            p.PhoneNumber = person.PhoneNumber;

            return Request.CreateResponse(HttpStatusCode.OK, person);

        }


        public Person Get(string firstName)
        {
            var person = Person.All.FirstOrDefault(m => m.FirstName.Equals(firstName));
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Person with first name {0} not found", firstName)));
                
            }

            return person;
        }

        //[HttpDelete]
        //public HttpResponseMessage RemovePerson(int id)
        //{
        //    var person = Person.All.FirstOrDefault(m => m.Id.Equals(id));
        //    if (person==null)
        //    {
        //        throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Person with id {0} not found", id)));

        //    }

        //    Person.All.Remove(person);
        //    return Request.CreateResponse(HttpStatusCode.OK, string.Format("Successfully deleted {0} from the system.", person.FirstName));
            
        //}

        
    }
}
