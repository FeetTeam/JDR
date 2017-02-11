using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PathfinderAdventure;
using PathfinderAdventure.BasePathFinder;

namespace PathfinderWebServiceLib
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ICharacterService
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        IEnumerable<Character> GetCharacters();

        [OperationContract]
        Character GetCharacterPersoWs(string name);

        [OperationContract]
        List<Ability> GetAbilities();

        [OperationContract]
        void CreateCharacter(CharacterWs c);
    }

    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    // Vous pouvez ajouter des fichiers XSD au projet. Une fois le projet généré, vous pouvez utiliser directement les types de données qui y sont définis, avec l'espace de noms "PathfinderWebServiceLib.ContractType".
    //[DataContract]
    //public class CompositeType : ICharacter
    //{
    //    [DataMember]
    //    public AbilitiesSet Abilities { get; set; }

    //    [DataMember]
    //    public Alignment Alignment { get; set; }

    //    [DataMember]
    //    public int ArmorClass { get; set; }

    //    [DataMember]
    //    public List<Armor> Armors { get; set; }

    //    [DataMember]
    //    public IEnumerable<CharacterClass> Classes { get; set; }

    //    [DataMember]
    //    public List<ClassFeat> ClassFeats { get; set; }

    //    [DataMember]
    //    public Coins CoinsQuantity { get; set; }

    //    [DataMember]
    //    public List<Equipment> Equipments { get; set; }

    //    [DataMember]
    //    public FeatsSet Feats { get; set; }

    //    [DataMember]
    //    public int Gender { get; set; }

    //    [DataMember]
    //    public int HealthPoint { get; set; }

    //    [DataMember]
    //    public int Id { get; set; }

    //    [DataMember]
    //    public List<Language> Languages { get; set; }

    //    [DataMember]
    //    public string CharacterName { get; set; }

    //    [DataMember]
    //    public Race Race { get; set; }

    //    [DataMember]
    //    public List<RaceFeat> RaceFeats { get; set; }

    //    [DataMember]
    //    public SavingThrows SavingThrows { get; set; }

    //    [DataMember]
    //    public SkillSet Skills { get; set; }

    //    [DataMember]
    //    public List<Weapon> Weapons { get; set; }
    //}

    [DataContract]
    public class CharacterWs
    {
        [DataMember]
        public Character CharacterPersoWs { get; set; }
    }
}