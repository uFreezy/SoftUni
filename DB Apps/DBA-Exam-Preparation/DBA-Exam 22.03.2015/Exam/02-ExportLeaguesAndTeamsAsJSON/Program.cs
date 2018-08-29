using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballDatabase;

namespace _02_ExportLeaguesAndTeamsAsJSON
{
    class Program
    {
        static void Main()
        {
            var context = new FootballEntities();

            var data = context.Leagues.OrderBy(l => l.LeagueName).Select(l => new
            {
                leagueName = l.LeagueName,
                teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
            });

            JsonSerializer output = new JsonSerializer();
            output.Formatting = Formatting.Indented;
            output.NullValueHandling = NullValueHandling.Include;

            using (StreamWriter sw = new StreamWriter(@"../../leagues-and-teams.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                foreach (var entity in data)
                {
                   output.Serialize(writer, entity);
                }
            }

            Console.WriteLine("Successfully created JSON file!");
        }
    }
}
