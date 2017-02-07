/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 13:36
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of ClassFeat.
    /// </summary>
    public class ClassFeat
    {
        public int Id { get; set; }
        private string name;

        public string Name { get; set; }
        public string Description { get; set; }
        public int RequiredLevel { get; set; }

        public ClassFeat(int requiredLevel, string name, string description)
        {
            this.RequiredLevel = requiredLevel;
            this.name = name;
            this.Description = description;
        }
    }
}