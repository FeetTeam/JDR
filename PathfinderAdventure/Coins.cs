/*
 * Created by SharpDevelop.
 * User: jerome
 * Date: 06/02/2017
 * Time: 15:45
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace PathfinderAdventure
{
    /// <summary>
    /// Description of Coins.
    /// </summary>
    public class Coins
    {
        public int Id { get; set; }
        public int GoldCoins { get; set; }
        public int SilverCoins { get; set; }
        public int CopperCoins { get; set; }

        public Coins()
        {
            GoldCoins = 0;
            SilverCoins = 0;
            CopperCoins = 0;
        }

        public void winGoldCoins(int quantity)
        {
            GoldCoins += quantity;
        }

        public void spendGoldCoins(int quantity)
        {
            GoldCoins -= quantity;
        }

        public void winSilverCoins(int quantity)
        {
            SilverCoins += quantity;
        }

        public void wpendSilverCoins(int quantity)
        {
            SilverCoins -= quantity;
        }

        public void winCopperCoins(int quantity)
        {
            CopperCoins += quantity;
        }

        public void spendSilverCoins(int quantity)
        {
            CopperCoins -= quantity;
        }

        public int getTotal()
        {
            return GoldCoins * 100 + SilverCoins * 10 + CopperCoins;
        }
    }
}