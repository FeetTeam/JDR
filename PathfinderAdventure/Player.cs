/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 08:52
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Player.
    /// </summary>
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Player()
        {
        }

        public Player(string name = "(Unknown player)")
        {
        }
    }
}