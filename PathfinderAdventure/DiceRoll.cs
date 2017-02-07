/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 09:33
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of DiceRoll.
    /// </summary>
    public class DiceRoll
    {
        private List<Dice> dices;

        public DiceRoll()
        {
        }

        public DiceRoll(List<Dice> dices)
        {
            if (dices != null)
                dices = dices;
            else
                dices = new List<Dice>();
        }

        public void add(Dice dice)
        {
            dices.Add(dice);
        }

        public int roll()
        {
            int rollResult = 0;
            foreach (Dice dice in dices) rollResult += dice.roll();
            return rollResult;
        }
    }
}