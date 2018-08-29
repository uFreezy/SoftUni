using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using _06_Phonebook.Data;
using _06_Phonebook.Models;

namespace _07_ContactsFromJSON
{
    class Program
    {
        static void Main()
        {
            using (StreamReader r = new StreamReader("../../contacts.json"))
            {
                var context = new PhonebookContext();

                string json = r.ReadToEnd();
                JArray googleSearch = JArray.Parse(json);

                context.Contacts.Count();
                foreach (var var in googleSearch)
                {
                    if (var["name"] != null)
                    {
                        var emailsExist = var["emails"] != null;

                        var phonesExist = var["phones"] != null;

                        var contact = context.Contacts.Add(new Contact
                        {
                            Name = var["name"].ToString(),
                            Company = (var["company"] != null) ? var["company"].ToString() : null,
                            Notes = (var["notes"] != null) ? var["notes"].ToString() : null,
                            Position = (var["position"] != null) ? var["position"].ToString() : null,
                            SiteUrl = (var["site"] != null) ? var["site"].ToString() : null
                        });

                        if (emailsExist)
                        {
                            List<Email> emails = var["emails"].ToString().Split(',').Select(email => new Email
                            {
                                EmailAdress = email.Split('"')[1]
                            }).ToList();

                            contact.Emails = new List<Email>(emails);
                        }

                        if (phonesExist)
                        {
                              List<Phone> phones = var["phones"].ToString().Split(',').Select(phone => new Phone
                            {
                                PhoneNumber = phone.Split('"')[1]
                            }).ToList();

                            contact.Phones = new List<Phone>(phones);
                        }
                    }
                }
                context.SaveChanges();

                Console.WriteLine("Contacts imported from JSON file!");
            }

            
        }
    }
}
