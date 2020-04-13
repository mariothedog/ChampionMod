using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Items
{
    class ItemGlobal : GlobalItem
    {
        readonly static Dictionary<string, double> copperCoinConversions = new Dictionary<string, double>()
        {
            { "platinum", 1000000 },
            { "gold", 10000 },
            { "silver", 100 },
            { "copper", 1 }
        };

        readonly static Color platinumCoinColor = new Color(169, 169, 152);
        readonly static Color goldCoinColor = new Color(166, 148, 68);
        readonly static Color silverCoinColor = new Color(159, 169, 170);
        readonly static Color bronzeCoinColor = new Color(244, 136, 95);

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // Lucky cat sell price tooltip modification.
            if (Main.LocalPlayer.GetModPlayer<MyPlayer>().hasLuckyCat)
            {
                var price_tooltip = from tooltip in tooltips
                                    where tooltip.Name == "Price"
                                    select tooltip;

                // Check if there is a "Buy price"/"Sell price" tooltip.
                if (price_tooltip.Count() > 0)
                {
                    TooltipLine tip = price_tooltip.First();
                    string[] price_split = tip.text.Split(':');
                    string type = price_split[0];

                    if (type == "Sell price")
                    {
                        // Parse the tooltip add up the total copper coins.
                        double totalCopperCoins = 0;
                        string[] prices = price_split[1].Split(' ');
                        for (int i = 0; i < prices.Count(); i++)
                        {
                            if (prices[i].Any(c => char.IsDigit(c)))
                            {
                                totalCopperCoins += double.Parse(prices[i]) * copperCoinConversions[prices[i + 1]];
                            }
                        }

                        // Add 15%.
                        totalCopperCoins *= 1.15;

                        // Calculate the number of each amount of coins.
                        int copper_coins = (int)(totalCopperCoins % 100);
                        int silver_coins = (int)(totalCopperCoins / 100 % 100);
                        int gold_coins = (int)(totalCopperCoins / 10000 % 100);
                        int platinum_coins = (int)(totalCopperCoins / 1000000 % 100);

                        // Parse information back into the tooltip.
                        tip.text = "Sell price: ";
                        if (platinum_coins > 0)
                        {
                            tip.text += string.Format("{0} platinum ", platinum_coins);
                        }
                        if (gold_coins > 0)
                        {
                            tip.text += string.Format("{0} gold ", gold_coins);
                        }
                        if (silver_coins > 0)
                        {
                            tip.text += string.Format("{0} silver ", silver_coins);
                        }
                        if (copper_coins > 0)
                        {
                            tip.text += string.Format("{0} copper ", copper_coins);
                        }

                        // Remove space character at the end.
                        tip.text = tip.text.Trim();

                        // Set tooltip color.
                        if (platinum_coins > 0)
                        {
                            tip.overrideColor = platinumCoinColor;
                        }
                        else if (gold_coins > 0)
                        {
                            tip.overrideColor = goldCoinColor;
                        }
                        else if (silver_coins > 0)
                        {
                            tip.overrideColor = silverCoinColor;
                        }
                        else if (copper_coins > 0)
                        {
                            tip.overrideColor = bronzeCoinColor;
                        }
                    }
                }
            }
        }
    }
}