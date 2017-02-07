/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 15:18
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of RaceFeat.
    /// </summary>
    public class RaceFeat
    {
        public int Id { get; set; }

        public Race Race { get; set; }

        public string Description { get; set; }

        public RaceFeat()
        {
        }

        public RaceFeat(Race race, string description)
        {
            this.Race = race;
            this.Description = description;
        }
    }
}