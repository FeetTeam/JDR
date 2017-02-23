/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 02/10/2017
 * Time: 13:42
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of CharacterHealth.
    /// </summary>
    [DataContract]
    public class CharacterHealth
    {
        public enum VitalHealthState { ALIVE, DYING, DIED };

        public enum HealthAffliction { };

        public int Id { get; set; }
        public int MaxHealthPoint { get; set; }

        [DataMember]
        public int CurrentHealthPoint { get; set; }

        public int TmpMaxHealthPoint { get; set; }
        public int TmpCurrentHealthPoint { get; set; }
        public VitalHealthState HealthState { get; set; }
        public List<HealthAffliction> Afflictions { get; set; }

        public CharacterHealth()
        {
        }
    }
}