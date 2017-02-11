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
            //dbctxt.Database.CreateIfNotExists();
            //InitDb(dbctxt);
            var rep = new AbilitiesSetRepository();
            var res = rep.GetAbilitiesSets();

            var repCharact = new CharacterSetRepository();
            var res2 = repCharact.GetCharacterPerso("Beurk");
        }

        public static void InitDb(PathFinderDbContext dbCtxt)
        {
            var characterBeurk = dbCtxt.Characters.FirstOrDefault();
            if (characterBeurk == null)
            {
                characterBeurk = new Character { CharacterName = "Beurk", };
                var armor = new Armor("Armure en bronze") { };
                characterBeurk.Armors.Add(armor);
                characterBeurk.Gender = 1;
                characterBeurk.Race = new Race() { Name = "Barbar" };

                dbCtxt.Characters.Add(characterBeurk);
                dbCtxt.SaveChanges();
            }
        }
    }
}