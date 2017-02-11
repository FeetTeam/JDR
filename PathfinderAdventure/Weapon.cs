/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 14:04
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections;
using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Weapon.
    /// </summary>
    public class Weapon : Equipment
    {
        public enum WeaponAccessibility { SIMPLE, MARTIAL, EXOTIC };

        public enum WeaponHandling { LIGHT, ONE_HANDED, TWO_HANDED };

        public enum WeaponRange { MELEE, RANGED };

        public enum WeaponSpecialStatus { NONE, IMPROVISED, MONK, NONLETHAL };

        public Weapon.WeaponAccessibility Accessibility { get; set; }
        public Weapon.WeaponHandling Handling { get; set; }
        public Weapon.WeaponRange Range { get; set; }
        public Weapon.WeaponSpecialStatus SpecialStatus { get; set; }
        public bool Finessable { get; set; }
        public bool Reach { get; set; }
        public bool Projectile { get; set; }
        public bool Thrown { get; set; }
        public bool Composite { get; set; }
        public bool IsMagic { get; set; }
        public bool StrengthMalusSensitive { get; set; } /* Xbows */
        public bool DamageBludgeoning { get; set; }
        public bool DamagePiercing { get; set; }
        public bool DamageSlashing { get; set; }
        public IEnumerable Damages { get; set; }
        public int MagicBonus { get; set; }
        public int CompositeBonus { get; set; }
        public int CriticalFactor { get; set; }
        public List<int> CriticalNumbers { get; set; }
        public int RangeIncrement { get; set; }

        public Weapon()
        {
        }
    }
}