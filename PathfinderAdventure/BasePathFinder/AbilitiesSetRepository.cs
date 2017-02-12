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
            using (var dbCtxt = new PathFinderDbContext())
            {
                return dbCtxt.AbilitiesSets.Include("Strenght").ToList();
            }
        }

        public List<Ability> GetAbilities()
        {
            using (var dbCtxt = new PathFinderDbContext())
            {
                dbCtxt.Abilities.Load();
                return dbCtxt.Abilities.ToList();
            }
        }

        public void CreateAbilitySet(AbilitiesSet abilitiesSet)
        {
            using (var DbCtxt = new PathFinderDbContext())
            {
                Console.WriteLine("CreateAbilitySet");

                if (abilitiesSet.Id != 0)
                {
                    //ok
                    Console.WriteLine("Update");
                    DbCtxt.Entry(abilitiesSet).State = EntityState.Modified;
                    //var tmp = DbCtxt.Abilities.Find(abilitiesSet.Charisma.Id);
                    //DbCtxt.Abilities.Attach(tmp);

                    var charismConnected = DbCtxt.Abilities.First(x => x.Id == abilitiesSet.Charisma.Id);
                    charismConnected.Name = abilitiesSet.Charisma.Name;
                    DbCtxt.Entry(charismConnected).State = EntityState.Modified;
                    DbCtxt.Entry(abilitiesSet.Constitution).State = EntityState.Modified;
                }
                else
                {
                    Console.WriteLine("Create");
                    DbCtxt.AbilitiesSets.Add(abilitiesSet);
                }
                DbCtxt.SaveChanges();
            }
        }
    }
}