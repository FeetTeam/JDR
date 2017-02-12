/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 10:10
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Runtime.Serialization;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of CaracSet.
    /// </summary>
    [DataContract]
    public class AbilitiesSet
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Ability Strenght { get; set; }

        [DataMember]
        public Ability Constitution { get; set; }

        [DataMember]
        public Ability Dexterity { get; set; }

        [DataMember]
        public Ability Intelligence { get; set; }

        [DataMember]
        public Ability Widsom { get; set; }

        [DataMember]
        public Ability Charisma { get; set; }

        private Hashtable items;

        public AbilitiesSet()
        {
        }

        public AbilitiesSet(bool autoInit)
        {
            Strenght = new Ability(eAbilityID.STR);
            Constitution = new Ability(eAbilityID.CON);
            Dexterity = new Ability(eAbilityID.DEX);
            Intelligence = new Ability(eAbilityID.INT);
            Widsom = new Ability(eAbilityID.WIS);
            Charisma = new Ability(eAbilityID.CHA);

            items = new Hashtable();
            items.Add(eAbilityID.STR, Strenght);
            items.Add(eAbilityID.CON, Constitution);
            items.Add(eAbilityID.DEX, Dexterity);
            items.Add(eAbilityID.INT, Intelligence);
            items.Add(eAbilityID.WIS, Widsom);
            items.Add(eAbilityID.CHA, Charisma);
        }
    }
}