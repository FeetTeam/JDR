/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 12:43
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Skills.
    /// </summary>
    public class SkillSet
    {
        public int Id { get; set; }
        public List<Skill> Items { get; set; }

        public SkillSet()
        {
        }
    }
}