using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PathfinderAdventure.BasePathFinder
{
    public class PathFinderDbContext : DbContext
    {
        public PathFinderDbContext() : base("PfDb")
        {
        }

        //public PathFinderDbContext(string name) : base(name)
        //{
        //}

        public DbSet<AbilitiesSet> AbilitiesSets { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Armor> Armors { get; set; }

        //public DbSet<Adventure> Adventures { get; set; }
        //public DbSet<AdventureLevelList> AdventureLevelLists { get; set; }
        //public DbSet<Session> Sessions { get; set; }
        public DbSet<Coins> CoinsQuantity { get; set; }

        ////public DbSet<Armor> Armor { get; set; }
        public DbSet<Character> Characters { get; set; }

        ////public DbSet<CharacterClass> CharacterClass { get; set; }
        //public DbSet<ClassFeat> ClassFeats { get; set; }

        //public DbSet<Equipment> Equipments { get; set; }
        //public DbSet<Feat> Feats { get; set; }
        //public DbSet<FeatsSet> FeatSets { get; set; }
    }
}