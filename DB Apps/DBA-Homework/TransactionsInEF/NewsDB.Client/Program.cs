using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsDB.Data;
using NewsDB.Models;


namespace NewsDB.Client
{
    class Program
    {
        static void Main()
        {
            var context = new NewsDBContext();

            var data = context.News.Find(1);

            //WARNING: Concurency handling should be tested by running two instances of the app.

            while (true)
            {
                try
                {
                    data.Content = Console.ReadLine();
                    context.SaveChanges();
                    Console.WriteLine("Changes successfully saved in the DB.");
                    break;
                }
                catch (DbUpdateConcurrencyException exc)
                {
                    exc.Entries.Single().Reload();
                    Console.WriteLine("Conflict! Text from DB:" + context.News.Find(1).Content
                        + ". Enter the corrected text:");  
                }
            }         
        }   
    }
}
