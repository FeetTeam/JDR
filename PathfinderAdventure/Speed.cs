/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 15:21
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Speed.
    /// </summary>
    public class Speed
    {
        public enum SpeedCategory
        {
            M0, M6_5, M10, M13, M5
        }

        private SpeedCategory[] speeds;

        private int speedIndex;

        public Speed()
        {
        }

        public Speed(SpeedCategory category)
        {
            speedIndex = -1;

            speeds = new Speed.SpeedCategory[4];
            speeds[0] = SpeedCategory.M0;
            speeds[1] = SpeedCategory.M5;
            speeds[2] = SpeedCategory.M6_5;
            speeds[3] = SpeedCategory.M10;
            speeds[4] = SpeedCategory.M13;

            for (int i = 0; speedIndex > -1 && i < speeds.Length; i++) if (speeds[i] == category) speedIndex = i;
        }

        public void increaseSpeed()
        {
            if (speedIndex < speeds.Length - 1) speedIndex++;
        }

        public void decreaseSpeed()
        {
            if (speedIndex > 0) speedIndex--;
        }
    }
}