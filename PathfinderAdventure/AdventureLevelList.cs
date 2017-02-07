/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 08:42
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of LevelList.
    /// </summary>
    public class AdventureLevelList : List<int>
    {
        public int Id { get; set; }

        public AdventureLevelList() : base()
        {
            this.Capacity = 3;
        }
    }
}