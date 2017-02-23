/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 08:57
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Character.
    /// </summary>

    public class Character : ICharacter
    {
        /* From Base */
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gender { get; set; } // 0 female, 1 male, -1 non-binary / undefined
        public Alignment Alignment { get; set; }
        public Race Race { get; set; }
        public List<RaceFeat> RaceFeats { get; set; }
        public IEnumerable<CharacterClass> Classes { get; set; }
        public List<ClassFeat> ClassFeats { get; set; }
        public AbilitiesSet AbilitiesSet { get; set; }
        public SkillSet Skills { get; set; }
        public FeatsSet Feats { get; set; }
        public SavingThrows SavingThrows { get; set; }
        public List<int> BaseAttackBonus { get; set; }
        public List<Language> Languages { get; set; }
        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Equipment> Equipments { get; set; }
        public Armor ActiveArmor { get; set; }
        public Armor ActiveShield { get; set; }
        public Weapon ActiveWeapon { get; set; }
        public Coins CoinsQuantity { get; set; }
        public List<CharacterHealth> Health { get; set; }
        public Character AnimalCompanion { get; set; }
        public Player CharacterPlayer { get; set; }

        /* Computed on Load */

        [NotMapped]
        public int ArmorClass { get; set; }

        [NotMapped]
        public int DexModifyingWithArmor { get; set; }

        [NotMapped]
        public List<int> MeleeAttackBonus { get; set; }

        [NotMapped]
        public List<int> RangeAttackBonus { get; set; }

        [NotMapped]
        public int InitiativeBonus { get; set; }

        // [NotMapped]
        // public Bitmap Avatar { get; set; }

        public byte[] BytesAvatar { get; set; }

        public Character()
        {
            CoinsQuantity = new Coins() { };
            Armors = new List<Armor>();
        }

        private int computesArmorClass()
        {
            int armorClass;
            armorClass = DexModifyingWithArmor;
            if (ActiveArmor != null) armorClass += ActiveArmor.Bonus;
            if (ActiveShield != null) armorClass += ActiveShield.Bonus;
            armorClass += Race.Size.SizeArmorBonus;

            return armorClass;
        }

        // TODO Feat bonus, Special Bonus
        private List<int> computesMeleeAttackBonus()
        {
            List<int> meleeBonus = new List<int>();
            foreach (int BAB in BaseAttackBonus)
            {
                meleeBonus.Add(BAB + AbilitiesSet.Strenght.Modifying);
            }
            return meleeBonus;
        }

        // TODO Feat bonus, Special Bonus
        private List<int> computesRangedAttackBonus()
        {
            List<int> rangeBonus = new List<int>();
            foreach (int BAB in BaseAttackBonus)
            {
                rangeBonus.Add(BAB + DexModifyingWithArmor);
            }
            return rangeBonus;
        }

        private int computesDexModifyingWithArmor()
        {
            int realDexModifyingValue;

            if (ActiveArmor.MaxDexBonus < AbilitiesSet.Dexterity.Modifying)
                return ActiveArmor.MaxDexBonus;
            else return AbilitiesSet.Dexterity.Modifying;
        }

        private int computesInitBonus()
        {
            return DexModifyingWithArmor;
        }

        public Bitmap BytesToAvatar(byte[] src)
        {
            using (var streamReader = new MemoryStream(src))
            {
                return (Bitmap)Image.FromStream(streamReader);
            }
        }

        //public void AvatarToBytes(Image dst)
        //{
        //    using (var streamWriter = new MemoryStream())
        //    {
        //        Avatar.Save(streamWriter, ImageFormat.Png);
        //        BytesAvatar = streamWriter.ToArray();
        //    }
        //}

        public override string ToString()
        {
            //return $"{Id}:{Name}";
            return "{" + Id + "};{"+Name+"}";
        }
    }
}