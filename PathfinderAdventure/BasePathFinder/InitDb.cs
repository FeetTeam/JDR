using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathfinderAdventure.BasePathFinder
{
    public class InitDb
    {
        public static void Start()
        {
            PathFinderDbContext dbCtxt = new PathFinderDbContext();
            var character = new Character();

            character.AbilitiesSet = new AbilitiesSet
            {
                Charisma = new Ability { Name = "Charisma" },
                Constitution = new Ability { },
                Dexterity = new Ability { },
                Intelligence = new Ability { },
                Strenght = new Ability { },
                Widsom = new Ability { },
            };
            dbCtxt.AbilitiesSets.Add(character.AbilitiesSet);
            dbCtxt.SaveChanges();

            var charactClassList = new List<CharacterClass>();
            charactClassList.Add(new CharacterClass { Name = "Paladin", });
            charactClassList.Add(new CharacterClass { Name = "Prêtre", });

            dbCtxt.CharacterClass.AddRange(charactClassList);
            dbCtxt.SaveChanges();

            var races = new List<Race>();
            races.Add(new Race { Name = "Humain", Size = new CreatureSize { } });
            races.Add(new Race { Name = "Nain", Size = new CreatureSize { } });
            races.Add(new Race { Name = "Elfe", Size = new CreatureSize { } });
            races.Add(new Race { Name = "Orc", Size = new CreatureSize { } });
            dbCtxt.Races.AddRange(races);
            dbCtxt.SaveChanges();

            var armors = new List<Armor>();
            armors.Add(new Armor { Name = "Armure par défaut" });
            dbCtxt.Armors.AddRange(armors);
            dbCtxt.SaveChanges();

            //var shields = new List<Sh>

            var weapons = new Weapon[]
            {
                new Weapon { Name="Arme par défaut" },
                new Weapon { Name="Rapière" },
                new Weapon { Name="Epée une main" },
                new Weapon { Name="Epée deux mains" },
                new Weapon { Name="Lance pierre" },
                new Weapon { Name="Arc" },
            };
            dbCtxt.Weapons.AddRange(weapons);

            dbCtxt.SaveChanges();
        }
    }
}