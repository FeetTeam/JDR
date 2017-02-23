using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace PathfinderAdventure.BasePathFinder
{
    public class RacesRepository
    {
        public IEnumerable<Race> GetRaces()
        {
            using (var DbCtxt = new PathFinderDbContext())
            {
                Console.WriteLine("GetCharacters");
                return DbCtxt.Races.ToList();
            }
        }
    }
}