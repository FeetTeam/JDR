using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace PathfinderAdventure.BasePathFinder
{
    public class CharacterSetRepository
    {
        public PathFinderDbContext DbCtxt { get; set; }

        public CharacterSetRepository()
        {
        }

        public CharacterSetRepository(PathFinderDbContext ctxt)
        {
            DbCtxt = ctxt;
        }

        public Character GetFirstIdiot()
        {
            Console.WriteLine("CreateCharacter");
            return DbCtxt.Characters.Include("Abilities").Include("CoinsQuantity").First();
        }

        public IEnumerable<Character> GetCharacters()
        {
            Console.WriteLine("GetCharacters");
            return DbCtxt.Characters.Include("Abilities").Include("CoinsQuantity").ToList();
        }

        public Character GetCharacterPerso(string name)
        {
            Console.WriteLine("GetCharacterPerso");
            //DbCtxt.Characters.Load();
            var res = DbCtxt.Characters.Include("CoinsQuantity").FirstOrDefault(x => x.CharacterName.StartsWith(name));
            return res;
        }

        public void CreateCharacter(Character c)
        {
            Console.WriteLine("CreateCharacter");
            DbCtxt = new PathFinderDbContext();
            //var entityChanged = DbCtxt.ChangeTracker.Entries();

            var persoExistant = DbCtxt.Entry(c);

            if (persoExistant != null)
            {
                Console.WriteLine("Update");
                DbCtxt.Characters.Attach(c);
                persoExistant.State = EntityState.Modified;
                DbCtxt.Entry(persoExistant.Entity.CoinsQuantity).State = EntityState.Modified;
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