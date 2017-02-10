/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 09:33
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of DiceRoll.
    /// </summary>
    public class DiceRoll
    {
        private List<Dice> dices;
        private DiceRollModifying modifying;

        public DiceRoll()
        {
        }

        public DiceRoll(List<Dice> dices, DiceRollModifying modifying = null)
        {
            if (dices != null)
                this.dices = dices;
            else
                this.dices = new List<Dice>();
            
            if(modifying != null)
            	this.modifying = modifying;
            else this.modifying = new DiceRollModifying(0);
        }

        public void add(Dice dice)
        {
            dices.Add(dice);
        }

        
        public int roll()
        {
            int rollResult = 0;
            foreach (Dice dice in dices) rollResult += dice.roll();
            return rollResult + modifying.Value;
        }
        
        public void rollSeparately(int[]rollResult)
        {
        	for(int i=0; i<dices.Count && i < rollResult.Length; i++) rollResult[i] += dices[i].roll();
        	if(rollResult.Length > dices.Count){
        		for(int i = 0; i < dices.Count; i++) 
        			rollResult[dices.Count] += rollResult[i];
        		rollResult[dices.Count] += modifying.Value;
        	}
        }
    }
}