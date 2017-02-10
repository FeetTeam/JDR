using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Ability> GetAbilities()
        {
            var dbCtxt = new PathFinderDbContext();
            dbCtxt.Abilities.Load();
            return dbCtxt.Abilities.ToList();
        }
    }
}