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

        // POST api/person
        public HttpResponseMessage Post([FromBody]string FirstName)
        {
            //person.Id = Person.All.Max(m => m.Id) + 1;
            //Person.All.Add(person);
            //return Request.CreateResponse(HttpStatusCode.OK, person);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT api/person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/person/5
        //[HttpPost]
        public HttpResponseMessage Delete([FromBody] int personId)
        {
            var person = Person.All.FirstOrDefault(m => m.Id.Equals(personId));
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("Person with id {0} not found", personId)));

            }

            Person.All.Remove(person);
            return Request.CreateResponse(HttpStatusCode.OK, string.Format("Successfully deleted {0} from the system.", person.FirstName));

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
