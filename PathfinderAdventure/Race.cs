/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 14:28
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Race.
    /// </summary>
    public class Race
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CreatureSize Size { get; set; }
        public List<Language> Languages { get; set; }
        public CharacterClass FavoredClass { get; set; }
        public int LevelAdjustment { get; set; }
        public List<RaceFeat> RaceFeats { get; set; }

        public Race()
        {
            Languages = new List<Language>();
            RaceFeats = new List<RaceFeat>();
        }
    }
}