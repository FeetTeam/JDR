/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 14:02
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Equipment.
    /// </summary>
    public class Equipment
    {
        public enum EquipmentType { WEAPON, ARMOR, POISON, ADVENTURING_GEAR, MAGIC_ITEM, QUEST_ITEM, PRIVATE_ITEM }

        public int Id { get; set; }

        public string Name { get; set; }
        public Equipment.EquipmentType TypeEquipement { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int StandardCost { get; set; }

        public Equipment()
        {
        }
    }
}