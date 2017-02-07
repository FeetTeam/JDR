/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 12:42
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Skill.
    /// </summary>
    public class Skill
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public Ability RelatedCarac { get; set; }
        public int Val { get; set; }

        private int[] bonus; // misc bonus

        private int skillPoints; // skill points spend in that skill

        public Skill()
        {
        }

        public Skill(Ability relatedCarac, string name = "(Unknown)", int skillPoints = -1, int[] bonus = null)
        {
            this.RelatedCarac = relatedCarac;
            if (bonus != null) this.bonus = bonus;
            else this.bonus = new int[] { 0 };
            if (skillPoints > 0) this.skillPoints = skillPoints;
            else this.skillPoints = 0;

            Val = relatedCarac.Modifying + skillPoints;
            for (int i = 0; i < bonus.Length; i++) Val += bonus[i];
        }

        public void setInvestedSP(int skillPoints)
        {
            this.skillPoints = skillPoints;
        }

        public void addSkillPoints(int skillPoints)
        {
            this.skillPoints += skillPoints;
        }
    }
}