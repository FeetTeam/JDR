/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 16:10
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of SavingThrows.
    /// </summary>
    public class SavingThrows
    {
        public int Fortitude { get; set; }

        public int Reflex { get; set; }

        public int Will { get; set; }

        public SavingThrows()
        {
        }

        public SavingThrows(int fortitude = 0, int reflex = 0, int will = 0)
        {
            this.Fortitude = fortitude;
            this.Reflex = reflex;
            this.Will = will;
        }
    }
}