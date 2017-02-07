/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 16:28
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Alignment.
    /// </summary>
    public class Alignment
    {
        public int Id { get; set; }

        public enum Good2Evil { GOOD, NEUTRAL, EVIL };

        public enum Lawful2Chaotic { LAWFUL, NEUTRAL, CHAOTIC };

        public Good2Evil GoodAlignment { get; set; }
        public Lawful2Chaotic LawfulAlignment { get; set; }
        public string NickName { get; set; }

        public Alignment()
        {
        }

        private void processNickName()
        {
            if (GoodAlignment == Good2Evil.GOOD)
            {
                if (LawfulAlignment == Lawful2Chaotic.LAWFUL)
                    NickName = "Le croisé";
                else if (LawfulAlignment == Lawful2Chaotic.NEUTRAL)
                    NickName = "Le bienfaiteur";
                else
                    NickName = "Le rebelle";
            }
            else if (GoodAlignment == Good2Evil.NEUTRAL)
            {
                if (LawfulAlignment == Lawful2Chaotic.LAWFUL)
                    NickName = "Le juge";
                else if (LawfulAlignment == Lawful2Chaotic.NEUTRAL)
                    NickName = "L'indécis";
                else
                    NickName = "L'esprit libre";
            }
            else
            {
                if (LawfulAlignment == Lawful2Chaotic.LAWFUL)
                    NickName = "Le sominateur";
                else if (LawfulAlignment == Lawful2Chaotic.NEUTRAL)
                    NickName = "Le malfaisant";
                else
                    NickName = "Le destructeur";
            }
        }
    }
}