using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathfinderAdventure.BasePathFinder
{
    public class AbilitiesSetRepository
    {
        public List<AbilitiesSet> GetAbilitiesSets()
        {
            var dbCtxt = new PathFinderDbContext();
            return dbCtxt.AbilitiesSets.Include("Strenght").ToList();
        }
    }
}