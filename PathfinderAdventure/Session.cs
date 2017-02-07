/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 08:49
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Session.
    /// </summary>
    public class Session
    {
        public int Id { get; set; }
        public Adventure Adventure { get; set; }
        public DateTime DateSession { get; set; }
        public List<Player> Players { get; set; }
        public SessionSummary Summary { get; set; }

        public Session()
        {
        }
    }
}