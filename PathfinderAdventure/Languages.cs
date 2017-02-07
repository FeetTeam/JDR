/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 15:13
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Languages.
    /// </summary>
    public class Languages
    {
        public int Id { get; set; }
        public List<Language> Items { get; set; }

        public Languages()
        {
            Items = new List<Language>();
        }

        public void add(Language language)
        {
            this.Items.Add(language);
        }
    }
}