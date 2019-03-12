using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PhoneBook.DM;

namespace PhoneBookSPA.Controllers
{
    public class PhoneBookController : ApiController
    {
        private readonly IOperations _operations;

        public PhoneBookController()
        {
        }
        public PhoneBookController(IOperations operations)
        {
            _operations = operations;
        }
        // GET: api/PhoneBook
        public List<DmEntry> Get([FromUri]string userInternalId)
        {
            var entries = _operations.GetEntries(userInternalId);
            return entries;
        }

        // GET: api/PhoneBook/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PhoneBook
        public HttpResponseMessage Post([FromBody]DmEntryEx entry)
        {
            if (!string.IsNullOrEmpty(entry.Number) && !string.IsNullOrEmpty(entry.Person))
            {
                var result = _operations.AddEntry(entry);
                if (result == "Success")
                {
                    return Request.CreateResponse(HttpStatusCode.Created, entry);
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Unsuccesfull");
        }

        // PUT: api/PhoneBook/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PhoneBook/5
        public void Delete(int id)
        {
        }
    }
}
