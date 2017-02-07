/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 10:10
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of CaracSet.
    /// </summary>
    public class AbilitiesSet
    {
        public int Id { get; set; }

        public Ability Strenght { get; set; }
        public Ability Constitution { get; set; }
        public Ability Dexterity { get; set; }
        public Ability Intelligence { get; set; }
        public Ability Widsom { get; set; }
        public Ability Charisma { get; set; }

        private Hashtable items;

        public AbilitiesSet()
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