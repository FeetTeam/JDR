using PathfinderAdventure;
using PathfinderAdventure.BasePathFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCodeFirst
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var dbctxt = new PathFinderDbContext();
            //dbctxt.Database.Create();
            InitDb(dbctxt);
            var rep = new AbilitiesSetRepository();
            var res = rep.GetAbilitiesSets();
        }

        public static void InitDb(PathFinderDbContext dbCtxt)
        {
            var characterBeurk = dbCtxt.Characters.FirstOrDefault(x => x.Name == "Beurk");
            if (characterBeurk != null)
            {
                var character = new Character { Name = "Beurk", };
                var armor = new Armor("Armure en bronze") { };
                character.Armors.Add(armor);
                dbCtxt.Characters.Add(character);
                dbCtxt.SaveChanges();
            }
        }
    }
}