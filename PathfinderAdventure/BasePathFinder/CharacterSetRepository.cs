using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PathfinderAdventure.BasePathFinder
{
    public class CharacterSetRepository
    {
        public CharacterSetRepository()
        {
        }

        public Character GetFirstIdiot()
        {
            using (var DbCtxt = new PathFinderDbContext())
            {
                Console.WriteLine("CreateCharacter");
                return DbCtxt.Characters.Include("Abilities").Include("CoinsQuantity").First();
            }
        }

        public IEnumerable<Character> GetCharacters()
        {
            using (var DbCtxt = new PathFinderDbContext())
            {
                Console.WriteLine("GetCharacters");
                return DbCtxt.Characters.Include("Abilities").Include("CoinsQuantity").ToList();
            }
        }

        public Character GetCharacterPerso(string name)
        {
            using (var DbCtxt = new PathFinderDbContext())
            {
                Console.WriteLine("GetCharacterPerso");
                var res = DbCtxt.Characters.Include("CoinsQuantity").FirstOrDefault(x => x.Name.StartsWith(name));
                return res;
            }
        }

        public void CreateCharacter(Character c)
        {
            using (var DbCtxt = new PathFinderDbContext())
            {
                Console.WriteLine("CreateCharacter");

                if (c.Id != 0)
                {
                    //ok
                    Console.WriteLine("Update");
                    //DbCtxt.Characters.Attach(persoExistant);
                    DbCtxt.Entry(c).State = EntityState.Modified;
                    DbCtxt.Entry(c.CoinsQuantity).State = EntityState.Modified;
                }
                else
                {
                    Console.WriteLine("Create");
                    DbCtxt.Characters.Add(c);
                }
                DbCtxt.SaveChanges();
            }
        }
    }
}