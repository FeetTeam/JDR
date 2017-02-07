/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 08:40
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public class Adventure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public AdventureLevelList LevelList { get; set; }

        public Adventure()
        {
        }

        public Adventure(string name = "", string synopsis = "", AdventureLevelList levelList = null)
        {
            name = "(Unknown)";
            synopsis = "(No synopsis)";
            if (levelList == null) levelList = new AdventureLevelList();
        }
    }
}