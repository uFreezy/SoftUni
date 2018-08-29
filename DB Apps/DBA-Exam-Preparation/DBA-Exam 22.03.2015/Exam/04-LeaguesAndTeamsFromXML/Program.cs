using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FootballDatabase;

namespace _04_LeaguesAndTeamsFromXML
{
    class Program
    {
        static void Main()
        {
            var context = new FootballEntities();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../leagues-and-teams.xml");

            XmlNode Root = doc.DocumentElement;

            var leagueNumb = 0;

            foreach (XmlNode node in Root.ChildNodes)
            {
                leagueNumb++;

                Console.WriteLine("Processing league #{0} ...",leagueNumb);

                string leagueName = "";

                if (node.FirstChild != null && node.FirstChild.Name == "league-name" &&
                    !context.Leagues.Any(l => l.LeagueName == node.FirstChild.InnerText.ToString()))
                {
                    context.Leagues.Add(new League
                    {
                        LeagueName = node.FirstChild.InnerText
                    });

                    leagueName = node.FirstChild.InnerText;

                    Console.WriteLine("Created league: {0}", node.FirstChild.InnerText);
                    context.SaveChanges();
                }

                else
                {
                    if (node.FirstChild != null && node.FirstChild.InnerText != "")
                    {
                        Console.WriteLine("Existing league: {0}", node.FirstChild.InnerText);
                        context.SaveChanges();
                    }
                    
                } 

                if (node["teams"] != null && node["teams"].HasChildNodes)
                {
                    foreach (XmlNode team in node["teams"].ChildNodes)
                    {
                        if (team.Attributes["name"].Value != null)
                        {
                            var name = team.Attributes["name"].Value;
                            var country =  (team.Attributes["country"] != null) ? team.Attributes["country"].Value : "";

                            if (country != "" && 
                                !context.Teams.Any(t => t.TeamName == name && t.Country.CountryName == country))
                            {

                               var addTeam =  context.Teams.Add(new Team
                                {
                                    TeamName = name,
                                    CountryCode = context.Countries
                                    .First(c => c.CountryName == country).CountryCode
                                                          
                                });

                               

                                if (leagueName != "" && addTeam.Leagues.Count == 0)
                                {
                                    addTeam.Leagues.Add(context.Leagues
                                    .FirstOrDefault(l => l.LeagueName == leagueName));

                                    Console.WriteLine("Added team to league: {0} to {1}",addTeam.TeamName,leagueName);
                                }

                                Console.WriteLine("Created team: {0} ({1})",
                                    addTeam.TeamName,
                                   addTeam.Country.CountryName ?? "no country");                              
                            }

                            else if (country == "")
                            {
                                var addTeam = context.Teams.Add(new Team
                                {
                                    TeamName = name
                                });

                                if (leagueName != "")
                                {
                                    addTeam.Leagues.Add(context.Leagues
                                        .FirstOrDefault(l => l.LeagueName == leagueName));
                                    Console.WriteLine("Added team to league: {0} to {1}", addTeam.TeamName, leagueName);
                                }

                                Console.WriteLine("Created team: {0} ({1})",
                                    addTeam.TeamName, "no country");
                            }

                            else
                            {
                                Console.WriteLine("Existing team: {0} ({1})", team.Attributes["name"].Value, (country == "") ? "no country" : country);
                            }

                        }
                    }
                    
                }


            }
            context.SaveChanges();
        }
    }
}
