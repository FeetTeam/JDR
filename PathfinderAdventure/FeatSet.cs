/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 13:34
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Feats.
    /// </summary>
    public class FeatsSet
    {
        public int Id { get; set; }

        public List<Feat> Items { get; set; }

        public FeatsSet()
        {
        }
    }
}