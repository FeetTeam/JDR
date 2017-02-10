/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 02/10/2017
 * Time: 13:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PathfinderAdventure
{
	/// <summary>
	/// Description of CreatureSize.
	/// </summary>
	public class CreatureSize
	{
		public enum CreatureSizeType { SMALL, MEDIUM, LARGE };
        public enum CreatureSpeedType { M6_5, M10 };
        	
        public CreatureSizeType Type { get; set; }
        public CreatureSpeedType SpeedType { get; set; }
        public int SpeedInMeters { get; set; }
        public int SpeedInInches { get; set; }
        public int SpeedInSquares { get; set; } 
        public int SizeArmorBonus { get; set; }
        	
		public CreatureSize()
		{

		}
	}
}
