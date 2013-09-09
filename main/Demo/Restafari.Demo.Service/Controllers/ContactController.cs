using System.Collections.Generic;
using System.Web.Http;
using Restafari.Demo.Service.Models;

namespace Restafari.Demo.Service.Controllers
{
    public class ContactController : ApiController
    {
        private readonly ContactStore contactStore = new ContactStore();
        // GET api/contact
        public IEnumerable<Contact> Get()
        {
            return this.contactStore.GetAll();
        }

        // GET api/contact/5
        public Contact Get(int id)
        {
            return this.contactStore.GetById(id); 
        }

        // POST api/contact
        public void Post([FromBody]Contact value)
        {
            this.contactStore.Create(value);
        }

        // PUT api/contact/5
        public void Put(int id, [FromBody]Contact value)
        {
            this.contactStore.Update(id, value);
        }

        // DELETE api/contact/5
        public void Delete(int id)
        {
            this.contactStore.Delete(id); 
        }
    }
}
