/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 09:00
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of CharacterClass.
    /// </summary>
    public class CharacterClass : ICharacterClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ClassFeat>[] ClassFeats { get; set; }

        public List<SavingThrows> SavingThrows { get; set; }

        public CharacterClass()
        {
            SavingThrows = new List<SavingThrows>();
        }

        public CharacterClass(string name, string description) : this()
        {
            this.Name = name;
            this.Description = description;
            ClassFeats = new List<ClassFeat>[20];
            // TODO derived class and instanciation of specific class feats
        }
    }
}