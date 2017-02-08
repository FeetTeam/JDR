using System.Collections.Generic;
using System.Linq;
/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 09:58
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    public enum eAbilityID { STR, CON, DEX, INT, WIS, CHA };

    /// <summary>
    /// Description of Carac.
    /// </summary>
    public class Ability
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Value { get; set; }
        public int TmpValue { get; set; }
        public int Modifying { get; set; }

        public Ability()
        {
        }

        public Ability(eAbilityID caracType, int value = 10)
        {
            this.Id = (int)caracType;

            switch (Id)
            {
                case (int)eAbilityID.STR:
                    Name = "Force";
                    break;

                case (int)eAbilityID.CON:
                    Name = "Constitution";
                    break;

                case (int)eAbilityID.DEX:
                    Name = "Dextérité";
                    break;

                case (int)eAbilityID.INT:
                    Name = "Intelligence";
                    break;

                case (int)eAbilityID.WIS:
                    Name = "Sagesse";
                    break;

                case (int)eAbilityID.CHA:
                    Name = "Charisme";
                    break;

                default:
                    break;
            }
            this.Value = value;
            Modifying = processBonus();
        }

        public void addPoint(int point = 1)
        {
            Value += point;
            Modifying = processBonus();
        }

        public void removePoint(int point = 1)
        {
            Value -= point;
            Modifying = processBonus();
        }

        public void setValue(int value)
        {
            this.Value = value;
            Modifying = processBonus();
        }

        private int processBonus()
        {
        	if(Value < 10 && Value % 2 == 1) return (Value - 10) / 2 - 1;
        	else return (Value - 10) / 2;
        }
        
        public static int generateAbilitieScore()
		{
			int [] rollResult = new int[4];
			DiceRoll diceRoll = new DiceRoll(new List<Dice> {DiceSet.D6, DiceSet.D6, DiceSet.D6, DiceSet.D6});
			diceRoll.rollSeparately(rollResult);			

			return rollResult.OrderByDescending(x => x).Take(3).Sum();
		}
    }
}