using System;

namespace Restafari.Demo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new DemoClient("localhost:45340");

            var contact = new Contact
                              {
                                  Name = "Fernando Escolar",
                                  Address = "9012 State st",
                                  City = "Barcelona",
                                  State = "CAT",
                                  Zip = "08034",
                                  Email = "fescolar@example.com",
                                  Twitter = "fernandoescolar"
                              };

            client.AddContact(contact);

            var contacts = client.GetContacts();
            Console.WriteLine("Contacts: " + contacts.Count);

            var push = new PushClient("localhost:45340");
            push.Subscribe();

            Console.ReadLine();
        }
    }
}
