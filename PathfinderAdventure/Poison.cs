/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 14:58
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Poison.
    /// </summary>
    public class Poison : Equipment
    {
        public enum PoisonCategory { CONTACT, INGESTED, INHALED, INJURY };

        public PoisonCategory category { get; set; }
        public int DifficultyClass { get; set; }
        public string InitialDamageDescription { get; set; }
        public string SecondaryDamageDescription { get; set; }

        public Poison()
        {
        }
    }
}