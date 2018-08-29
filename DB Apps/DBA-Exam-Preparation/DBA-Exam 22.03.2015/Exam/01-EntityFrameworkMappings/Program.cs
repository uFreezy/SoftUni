using System;
using FootballDatabase;

namespace _01_EntityFrameworkMappings
{
    class Program
    {
        static void Main()
        {
            //To test your EF data model, list all team names.
            // The rest of problem 1 is in separate project.

            var context =  new FootballEntities();

            foreach (var team in context.Teams)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
}
