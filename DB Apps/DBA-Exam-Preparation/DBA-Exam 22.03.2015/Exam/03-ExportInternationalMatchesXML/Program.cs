using System;
using System.Linq;
using System.Xml;
using FootballDatabase;

namespace _03_ExportInternationalMatchesXML
{
    class Program
    {
        static void Main()
        {
            var context = new FootballEntities();

            var data = context.InternationalMatches
                .Select(im => new
                {
                    im.HomeCountryCode,
                    im.AwayCountryCode,
                    HomeCountry = im.Country1.CountryName,
                    AwayCountry = im.Country.CountryName,
                    im.MatchDate,
                    im.League.LeagueName,
                    im.HomeGoals,
                    im.AwayGoals
                })
                .OrderBy(im => im.MatchDate)
                .ThenBy(im => im.HomeCountry)
                .ThenBy(im => im.AwayCountry);
            //Order the matches by date (from the earliest) and by home country and 
            //away country alphabetically as second and third criteria.
            var doc = new XmlDocument();

            var xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            var root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            var matches = doc.CreateElement(string.Empty, "matches", string.Empty);

            

            foreach (var entity in data)
            {
                XmlNode match = doc.CreateElement("match");

                if (entity.MatchDate != null)
                {
                    if (entity.MatchDate.Value.TimeOfDay.TotalSeconds > 0)
                    {
                        var date = doc.CreateAttribute("date-time");
                        date.Value = String.Format("{0:MM-dd-yyyy hh:mm}", entity.MatchDate);
                        match.Attributes.Append(date);
                    }
                    else
                    {
                        var date = doc.CreateAttribute("date");

                        date.Value = String.Format("{0:MM-dd-yyyy}", entity.MatchDate);
                        match.Attributes.Append(date);
                    }
                    
                }

                XmlNode homeCountry = doc.CreateElement("home-country");

                var homeCountryCode = doc.CreateAttribute("code");
                homeCountryCode.Value = entity.HomeCountryCode;
                homeCountry.Attributes.Append(homeCountryCode);
                homeCountry.InnerText = entity.HomeCountry;
                match.AppendChild(homeCountry);

                XmlNode awayCountry = doc.CreateElement("away-country");

                var awayCountryCode = doc.CreateAttribute("code");
                awayCountryCode.Value = entity.AwayCountryCode;
                awayCountry.Attributes.Append(awayCountryCode);
                awayCountry.InnerText = entity.AwayCountry;
                match.AppendChild(awayCountry);

                if (entity.HomeGoals != null && entity.AwayGoals != null)
                {
                    XmlNode goals = doc.CreateElement("goals");
                    goals.InnerText = entity.HomeGoals + "-" + entity.AwayGoals;
                    match.AppendChild(goals);
                }

                if (entity.LeagueName != null)
                {
                    XmlNode league = doc.CreateElement("leauge");
                    league.InnerText = entity.LeagueName;
                    match.AppendChild(league);
                }
                matches.AppendChild(match);
            }

            doc.AppendChild(matches);

            doc.Save("../../international-matches.xml");

            Console.WriteLine("XML creation completed!");
        }
    }
}
