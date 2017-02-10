/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 02/10/2017
 * Time: 13:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PathfinderAdventure
{
	/// <summary>
	/// Description of DiceRollModifying.
	/// </summary>
	public class DiceRollModifying
	{
		public int Value {get; set; }
		public string Description { get; set; }
		
		public DiceRollModifying(int value, string description = "Modificateur indéterminé")
		{
			this.Value = value;
			this.Description = description;
		}
	}
}
