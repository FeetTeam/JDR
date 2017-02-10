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
    public class Character
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
        public AbilitiesSet Abilities { get; set; }
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
        
        /* Computed on Load */
		public int ArmorClass { get; set; }
        public int DexModifyingWithArmor { get; set; }
        public List<int> MeleeAttackBonus { get; set; }
        public List<int> RangeAttackBonus { get; set; }
        public int InitiativeBonus { get; set; }
        
        public Character()
        {
            CoinsQuantity = new Coins() { };
            Armors = new List<Armor>();
        }
        
        private int computesArmorClass(){
        	int armorClass;
        	armorClass = DexModifyingWithArmor;
        	if(ActiveArmor != null) armorClass += ActiveArmor.Bonus;
        	if(ActiveShield != null) armorClass += ActiveShield.Bonus;
        	armorClass += Race.Size.SizeArmorBonus;
        	
        	return armorClass;
        }
        
        // TODO Feat bonus, Special Bonus
        private List<int> computesMeleeAttackBonus(){
        	List<int> meleeBonus = new List<int>();
        	foreach(int BAB in BaseAttackBonus){
        		meleeBonus.Add(BAB + Abilities.Strenght.Modifying);
        	}
        	return meleeBonus;
        }
        
        // TODO Feat bonus, Special Bonus
        private List<int> computesRangedAttackBonus(){
        	List<int> rangeBonus = new List<int>();
        	foreach(int BAB in BaseAttackBonus){
        		rangeBonus.Add(BAB + DexModifyingWithArmor);
        	}
        	return rangeBonus;
        }
        
        private int computesDexModifyingWithArmor(){
        	int realDexModifyingValue;
        	
        	if(ActiveArmor.MaxDexBonus < Abilities.Dexterity.Modifying)
        		return ActiveArmor.MaxDexBonus;
        	else return Abilities.Dexterity.Modifying;
        }
        
        private int computesInitBonus(){
        	return DexModifyingWithArmor;
        }
        
    }
}