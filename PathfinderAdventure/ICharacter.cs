using System.Collections.Generic;

namespace PathfinderAdventure
{
    public interface ICharacter
    {
        AbilitiesSet Abilities { get; set; }
        Alignment Alignment { get; set; }
        int ArmorClass { get; set; }
        List<Armor> Armors { get; set; }
        IEnumerable<CharacterClass> Classes { get; set; }
        List<ClassFeat> ClassFeats { get; set; }
        Coins CoinsQuantity { get; set; }
        List<Equipment> Equipments { get; set; }
        FeatsSet Feats { get; set; }
        int Gender { get; set; }
        int HealthPoint { get; set; }
        int Id { get; set; }
        List<Language> Languages { get; set; }
        string CharacterName { get; set; }
        Race Race { get; set; }
        List<RaceFeat> RaceFeats { get; set; }
        SavingThrows SavingThrows { get; set; }
        SkillSet Skills { get; set; }
        List<Weapon> Weapons { get; set; }
    }
}