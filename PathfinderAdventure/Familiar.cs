/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 02/10/2017
 * Time: 13:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PathfinderAdventure
{
	/// <summary>
	/// Description of Familiar.
	/// </summary>
	public class Familiar
	{
		public Character CharacterSheet { get; set; }
		public bool Lost { get; set; }
		public TimeSpan LossDuration { get; set; }
		
		public Familiar()
		{
		}
	}
}
