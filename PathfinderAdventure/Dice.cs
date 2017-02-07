/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 09:05
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Dice.
    /// </summary>
    public class Dice
    {
        public enum DiceType { D4, D6, D8, D10, D12, D20, D100 };

        private int sides;
        private DiceType diceType;

        public Dice(DiceType diceType)
        {
            this.diceType = diceType;

            switch (diceType)
            {
                case DiceType.D4:
                    sides = 4;
                    break;

                case DiceType.D6:
                    sides = 6;
                    break;

                case DiceType.D8:
                    sides = 8;
                    break;

                case DiceType.D10:
                    sides = 10;
                    break;

                case DiceType.D12:
                    sides = 12;
                    break;

                case DiceType.D20:
                    sides = 20;
                    break;

                case DiceType.D100:
                    sides = 100;
                    break;
            }
        }

        public int roll()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            return random.Next(1, sides + 1);
        }
    }
}