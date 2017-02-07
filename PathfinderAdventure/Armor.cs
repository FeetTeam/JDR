/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 14:37
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Armor.
    /// </summary>
    public class Armor : Equipment
    {
        public int Id { get; set; }

        public enum ArmorType { ARMOR, SHIELD };

        public enum ArmorStyle { LIGHT, MEDIUM, HEAVY };

        public enum ArmorMaterial { METAL, NON_METAL };

        public ArmorType ArmorTypeProperty { get; set; }
        public ArmorStyle StyleProperty { get; set; }
        public ArmorMaterial Material { get; set; }
        public int Bonus 
		{
			get; 
			set; 
		}
        public int MaxDexBonus { get; set; }
        public int ArmorPenalty { get; set; }
        public int ArcaneSpellFailureChance { get; set; }
        public int SpeedReductionFactor { get; set; }

        public Armor(string name, string description = "")
        {
        }
    }
}