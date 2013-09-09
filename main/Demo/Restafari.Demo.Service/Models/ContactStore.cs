using System;
using System.Collections.Generic;
using System.Linq;

namespace Restafari.Demo.Service.Models
{
    public class ContactStore
    {
        private static readonly List<Contact> Contacts = new List<Contact>(GetDemoData());

        public IEnumerable<Contact> GetAll()
        {
            return Contacts;
        }

        public Contact GetById(int id)
        {
            return Contacts.First(c => c.ContactId == id);
        }

        public void Create(Contact value)
        {
            var id = Contacts.Max(c => c.ContactId) + 1;
            value.ContactId = id;

            Contacts.Add(value);
        }

        public void Update(int id, Contact value)
        {
            var contact = this.GetById(id);
            contact.Address = value.Address;
            contact.City = value.City;
            contact.Email = value.Email;
            contact.Name = value.Name;
            contact.State = value.State;
            contact.Twitter = value.Twitter;
            contact.Zip = value.Zip;
        }

        public void Delete(int id)
        {
            var contact = this.GetById(id);
            Contacts.Remove(contact);
        }

        private static List<Contact> GetDemoData()
        {
            return new List<Contact>
                       {
                           new Contact
                               {
                                   ContactId = 0,
                                   Name = "Debra Garcia",
                                   Address = "1234 Main St",
                                   City = "Redmond",
                                   State = "WA",
                                   Zip = "10999",
                                   Email = "debra@example.com",
                                   Twitter = "debra_example",
                                   Meetings = new List<Meeting>
                                                  {
                                                      new Meeting { MeetingId = 0, Date=new DateTime(2013, 2, 12, 10, 0, 0), Description = "Checking point", Type = MeetingType.FormalMeeting },
                                                      new Meeting { MeetingId = 1, Date=new DateTime(2013, 3, 15, 10, 0, 0), Description = "Checking point", Type = MeetingType.FormalMeeting },
                                                      new Meeting { MeetingId = 2, Date=new DateTime(2013, 4, 13, 10, 0, 0), Description = "Checking point", Type = MeetingType.FormalMeeting }
                                                  }
                               },
                           new Contact
                               {
                                   ContactId = 1,
                                   Name = "Thorsten Weinrich",
                                   Address = "5678 1st Ave W",
                                   City = "Redmond",
                                   State = "WA",
                                   Zip = "10999",
                                   Email = "thorsten@example.com",
                                   Twitter = "thorsten_example",
                                      Meetings = new List<Meeting>
                                                  {
                                                      new Meeting { MeetingId = 3, Date=new DateTime(2013, 9, 2, 11, 30, 0), Description = "Negozation", Type = MeetingType.FormalMeeting },
                                                      new Meeting { MeetingId = 4, Date=new DateTime(2013, 7, 15, 12, 52, 0), Description = "First contact", Type = MeetingType.PhoneCall },
                                                  }
                               },
                           new Contact
                               {
                                   ContactId = 2,
                                   Name = "Yuhong Li",
                                   Address = "9012 State st",
                                   City = "Redmond",
                                   State = "WA",
                                   Zip = "10999",
                                   Email = "yuhong@example.com",
                                   Twitter = "yuhong_example",
                                   Meetings = new List<Meeting>
                                                  {
                                                      new Meeting { MeetingId = 5, Date=new DateTime(2013, 2, 12, 10, 0, 0), Description = "Checking point", Type = MeetingType.PhoneCall },
                                                      new Meeting { MeetingId = 6, Date=new DateTime(2013, 3, 15, 10, 0, 0), Description = "Checking point", Type = MeetingType.Visit },
                                                      new Meeting { MeetingId = 7, Date=new DateTime(2013, 4, 13, 10, 0, 0), Description = "Checking point", Type = MeetingType.Lunch }
                                                  }
                               },
                           new Contact
                               {
                                   ContactId = 3,
                                   Name = "Jon Orton",
                                   Address = "3456 Maple St",
                                   City = "Redmond",
                                   State = "WA",
                                   Zip = "10999",
                                   Email = "jon@example.com",
                                   Twitter = "jon_example",
                                   Meetings = new List<Meeting>
                                                  {
                                                      new Meeting { MeetingId = 8, Date=new DateTime(2013, 5, 30, 10, 0, 0), Description = "Checking point", Type = MeetingType.PhoneCall },
                                                  }
                               },
                           new Contact
                               {
                                   ContactId = 4,
                                   Name = "Diliana Alexieva-Bosseva",
                                   Address = "7890 2nd Ave E",
                                   City = "Redmond",
                                   State = "WA",
                                   Zip = "10999",
                                   Email = "diliana@example.com",
                                   Twitter = "diliana_example"
                               }
                       };
        }
    }
}