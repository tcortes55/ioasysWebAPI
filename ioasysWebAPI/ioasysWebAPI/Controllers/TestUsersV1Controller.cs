using ioasysWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ioasysWebAPI.Controllers
{
    public class TestUsersV1Controller : ApiController
    {
        private TestUserV1[] testUsers = new TestUserV1[]
        {
        new TestUserV1 { id = 1, name = "Haleemah Redfern", email = "email1@mail.com", phone = "01111111", role = 1},
        new TestUserV1 { id = 2, name = "Aya Bostock", email = "email2@mail.com", phone = "01111111", role = 1},
        new TestUserV1 { id = 3, name = "Sohail Perez", email = "email3@mail.com", phone = "01111111", role = 1},
        new TestUserV1 { id = 4, name = "Merryn Peck", email = "email4@mail.com", phone = "01111111", role = 2},
        new TestUserV1 { id = 5, name = "Cairon Reynolds", email = "email5@mail.com", phone = "01111111", role = 3}
        };

        // GET: api/TestUsers
        [Route("api/v1/testusers")]
        public IEnumerable<TestUserV1> Get()
        {
            return testUsers;
            //return new string[] { "value1", "value2" };
        }

        // GET: api/TestUsers/5
        [Route("api/v1/testusers/{id}")]
        public IHttpActionResult Get(int id)
        {
            var testUser = testUsers.FirstOrDefault(x => x.id == id);

            if (testUser == null)
            {
                return NotFound();
            }

            return Ok(testUser);
            //return "value";
        }

        // POST: api/TestUsers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TestUsers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TestUsers/5
        public void Delete(int id)
        {
        }
    }
}
