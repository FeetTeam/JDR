using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PathfinderAdventure
{
    public interface ICharacter
    {
        AbilitiesSet AbilitiesSet { get; set; }
        Armor ActiveArmor { get; set; }
        Armor ActiveShield { get; set; }
        Weapon ActiveWeapon { get; set; }
        Alignment Alignment { get; set; }
        Character AnimalCompanion { get; set; }
        int ArmorClass { get; set; }
        List<Armor> Armors { get; set; }
        List<int> BaseAttackBonus { get; set; }
        IEnumerable<CharacterClass> Classes { get; set; }
        List<ClassFeat> ClassFeats { get; set; }
        Coins CoinsQuantity { get; set; }
        int DexModifyingWithArmor { get; set; }
        List<Equipment> Equipments { get; set; }
        FeatsSet Feats { get; set; }
        int Gender { get; set; }
        List<CharacterHealth> Health { get; set; }
        int Id { get; set; }
        int InitiativeBonus { get; set; }
        List<Language> Languages { get; set; }
        List<int> MeleeAttackBonus { get; set; }
        string Name { get; set; }
        Race Race { get; set; }
        List<RaceFeat> RaceFeats { get; set; }
        List<int> RangeAttackBonus { get; set; }
        SavingThrows SavingThrows { get; set; }
        SkillSet Skills { get; set; }
        List<Weapon> Weapons { get; set; }
    }
}