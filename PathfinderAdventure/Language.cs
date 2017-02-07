/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 15:12
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Language.
    /// </summary>
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Language()
        {
        }

        public Language(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}