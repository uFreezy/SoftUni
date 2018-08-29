using System.Collections.Generic;
using _06_Phonebook.Models;

namespace _06_Phonebook.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_06_Phonebook.Data.PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "_06_Phonebook.Data.PhonebookContext";
        }

        protected override void Seed(_06_Phonebook.Data.PhonebookContext context)
        {
            context.Contacts.AddOrUpdate(c => c.Name, 
                new Contact
                {
                    Name = "Peter Ivanov",
                    Position = "CTO",
                    Company =  "Smart Ideas",
                    Emails = new List<Email>
                    {
                        new Email { EmailAdress = "peter@gmail.com" },
                        new Email { EmailAdress = "peter_ivanov@yahoo.com" }
                    },
                    Phones = new List<Phone>
                    {
                        new Phone { PhoneNumber = "+359 2 22 22 22" },
                        new Phone { PhoneNumber = "+359 88 77 88 99" }
                    },
                    SiteUrl = "http://blog.peter.com",
                    Notes = "Friend from school"
                },
                new Contact
                {
                    Name = "Maria",
                    Phones = new List<Phone>
                    {
                        new Phone { PhoneNumber = "+359 22 33 44 55" }
                    }
                },
                new Contact
                {
                    Name = "Angie Stanton",
                    Emails = new List<Email>
                    {
                        new Email { EmailAdress = "info@angiestanton.com" }
                    },
                    SiteUrl = "http://angiestanton.com"
                }
            );
        }
    }
}
