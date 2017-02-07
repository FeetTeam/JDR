/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 09:43
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of DiceSet.
    /// </summary>
    public class DiceSet
    {
        private Dice d4;
        private Dice d6;
        private Dice d8;
        private Dice d10;
        private Dice d12;
        private Dice d20;
        private Dice d100;

        private static DiceSet current;

        public DiceSet()
        {
            d4 = new Dice(Dice.DiceType.D4);
            d6 = new Dice(Dice.DiceType.D6);
            d8 = new Dice(Dice.DiceType.D8);
            d10 = new Dice(Dice.DiceType.D10);
            d12 = new Dice(Dice.DiceType.D12);
            d20 = new Dice(Dice.DiceType.D20);
            d100 = new Dice(Dice.DiceType.D100);

            current = this;
        }

        static public Dice D4
        {
            get
            {
                if (current == null)
                    current = new DiceSet();
                return current.d4;
            }
        }

        static public Dice D6
        {
            get
            {
                if (current == null)
                    current = new DiceSet();
                return current.d6;
            }
        }

        static public Dice D8
        {
            get
            {
                if (current == null)
                    current = new DiceSet();
                return current.d8;
            }
        }

        static public Dice D10
        {
            get
            {
                if (current == null)
                    current = new DiceSet();
                return current.d10;
            }
        }

        static public Dice D12
        {
            get
            {
                if (current == null)
                    current = new DiceSet();
                return current.d12;
            }
        }

        static public Dice D20
        {
            get
            {
                if (current == null)
                    current = new DiceSet();
                return current.d20;
            }
        }

        static public Dice D100
        {
            get
            {
                if (current == null)
                    current = new DiceSet();
                return current.d100;
            }
        }
    }
}