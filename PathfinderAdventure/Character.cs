/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 08:57
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections;
using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Character.
    /// </summary>
    public class Character : ICharacter
    {
        public int Id { get; set; }

        public string CharacterName { get; set; }
        public int Gender { get; set; } // 0 female, 1 male, -1 non-binary / undefined
        public Alignment Alignment { get; set; }
        public Race Race { get; set; }
        public List<RaceFeat> RaceFeats { get; set; }
        public IEnumerable<CharacterClass> Classes { get; set; }
        public List<ClassFeat> ClassFeats { get; set; }
        public AbilitiesSet Abilities { get; set; }
        public SkillSet Skills { get; set; }
        public FeatsSet Feats { get; set; }
        public SavingThrows SavingThrows { get; set; }
        public List<Language> Languages { get; set; }
        public List<Weapon> Weapons { get; set; }

        public List<Equipment> Equipments { get; set; }

        public Coins CoinsQuantity { get; set; }
        public int ArmorClass { get; set; }

        public int HealthPoint { get; set; }
        public List<Armor> Armors { get; set; }

        public Character()
        {
            CoinsQuantity = new Coins();
        }
    }
}