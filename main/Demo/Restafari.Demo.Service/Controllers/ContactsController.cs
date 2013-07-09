using System.Collections.Generic;
using System.Web.Http;
using Restafari.Demo.Service.Models;

namespace Restafari.Demo.Service.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly ContactStore contactStore = new ContactStore();
        // GET api/contacts
        public IEnumerable<Contact> Get()
        {
            return this.contactStore.GetAll();
        }

        // GET api/contacts/5
        public Contact Get(int id)
        {
            return this.contactStore.GetById(id); 
        }

        // POST api/contacts
        public void Post([FromBody]Contact value)
        {
            this.contactStore.Create(value);
        }

        // PUT api/contacts/5
        public void Put(int id, [FromBody]Contact value)
        {
            this.contactStore.Update(id, value);
        }

        // DELETE api/contacts/5
        public void Delete(int id)
        {
            this.contactStore.Delete(id); 
        }
    }
}
