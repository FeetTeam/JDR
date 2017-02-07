/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 13:29
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Feat.
    /// </summary>
    public class Feat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Feat()
        {
        }

        public Feat(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}