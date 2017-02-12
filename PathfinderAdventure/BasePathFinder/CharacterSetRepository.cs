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
                return DbCtxt.Characters.First();
            }
        }

        public IEnumerable<Character> GetCharacters()
        {
            using (var DbCtxt = new PathFinderDbContext())
            {
                Console.WriteLine("GetCharacters");
                return DbCtxt.Characters.Include("Abilities").Include("TaMere").Include("CoinsQuantity").ToList();
            }
        }

        public Character GetCharacterPerso(string name)
        {
            using (var DbCtxt = new PathFinderDbContext())
            {
                Console.WriteLine("GetCharacterPerso");
                var res = DbCtxt.Characters.Include("CoinsQuantity")
                                           .Include(x => x.AbilitiesSet)
                                           .Include(x => x.AbilitiesSet.Charisma)
                                           .Include(x => x.AbilitiesSet.Constitution)
                                           .Include(x => x.AbilitiesSet.Dexterity)
                                           .Include(x => x.AbilitiesSet.Intelligence)
                                           .Include(x => x.AbilitiesSet.Strenght)
                                           .Include(x => x.AbilitiesSet.Widsom)
                                           .FirstOrDefault(x => x.Name.StartsWith(name));
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
                    DbCtxt.Entry(c).State = EntityState.Modified;
                    DbCtxt.Entry(c.CoinsQuantity).State = EntityState.Modified;
                    DbCtxt.Entry<AbilitiesSet>(c.AbilitiesSet).State = EntityState.Modified;
                    DbCtxt.Entry<Ability>(c.AbilitiesSet.Charisma).State = EntityState.Modified;
                    DbCtxt.Entry<Ability>(c.AbilitiesSet.Constitution).State = EntityState.Modified;
                    DbCtxt.Entry<Ability>(c.AbilitiesSet.Dexterity).State = EntityState.Modified;
                    DbCtxt.Entry<Ability>(c.AbilitiesSet.Intelligence).State = EntityState.Modified;
                    DbCtxt.Entry<Ability>(c.AbilitiesSet.Strenght).State = EntityState.Modified;
                    DbCtxt.Entry<Ability>(c.AbilitiesSet.Widsom).State = EntityState.Modified;
                }
                else
                {
                    Console.WriteLine("Create");
                    c.AbilitiesSet = new AbilitiesSet(true);

                    DbCtxt.Characters.Add(c);
                }
                DbCtxt.SaveChanges();
            }
        }
    }
}