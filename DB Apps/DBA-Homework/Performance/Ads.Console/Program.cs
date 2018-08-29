using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ads.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Net.Sockets;


namespace Ads.Console
{
    class Program
    {
        static void Main()
        {
            var context = new AdsEntities();

            context.Database.ExecuteSqlCommand("CHECKPOINT; DBCC DROPCLEANBUFFERS");

            //Problem 1

            //foreach (var ad in context.Ads
            //.Include(ad => ad.AdStatus)
            //.Include(ad => ad.Category)
            //.Include(ad => ad.Town)
            //.Include(ad => ad.AspNetUser))
            //{
            //    System.Console.WriteLine("{0} {1} {2} {3} {4}",
            //        ad.Title,
            //        ad.AdStatus.Status,
            //        (ad.Category != null) ? ad.Category.Name : "",
            //        (ad.Town != null) ? ad.Town.Name : "",
            //        ad.AspNetUser.Name);
            //}

            //Problem 2

            var stop = new Stopwatch();

            stop.Start();

            var allAdsRaw = context.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(ad => new
                {
                    ad.Title,
                    ad.Category,
                    ad.Town
                })
                .ToList();

            stop.Stop();
            System.Console.WriteLine("Raw: {0}",stop.Elapsed);

            stop.Reset();
            stop.Start();


            var allAdsOptimised = context.Ads
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(ad => new
                {
                    ad.Title,
                    ad.Category,
                    ad.Town
                })
                .ToList();

            stop.Stop();
            stop.Reset();

            System.Console.WriteLine("Optimised: {0}",stop.Elapsed);

            //Problem 3          

        }
    }
}
