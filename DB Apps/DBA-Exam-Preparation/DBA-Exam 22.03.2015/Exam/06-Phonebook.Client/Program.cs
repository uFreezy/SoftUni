using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06_Phonebook.Data;

namespace _06_Phonebook.Client
{
    class Program
    {
        static void Main()
        {
            var context = new PhonebookContext();

            var data = context.Contacts;

            foreach (var contact in data)
            {
                Console.WriteLine("Name: {0}{1}{2}{3}{4}{5}{6}",contact.Name,
                    (contact.Position != null) ? "\nPosition: " + contact.Position : "",
                    (contact.Company != null) ?  "\nCompany: " + contact.Company : "",
                    (contact.Emails.Any()) ? "\nEmails: " + string.Join(", ",contact.Emails.Select(x => x.EmailAdress).ToList()) : "",
                    (contact.Phones.Any()) ? "\nPhones: " + string.Join(", ", contact.Phones.Select(p => p.PhoneNumber).ToList()) : "",
                    (contact.SiteUrl != null) ? "\nUrl: " + contact.SiteUrl : "",
                    (contact.Notes != null) ? "\nNotes: " + contact.Notes : "");
                Console.WriteLine();
            }
        }
    }
}
