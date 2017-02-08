using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PathfinderAdventure.BasePathFinder
{
    public class CharacterSetRepository
    {
        public Character GetFirstIdiot()
        {
            var dbCtxt = new PathFinderDbContext();
            return dbCtxt.Characters.First();
        }
    }
}