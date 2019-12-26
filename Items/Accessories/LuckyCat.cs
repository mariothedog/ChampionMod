using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Accessories
{
    class LuckyCat : ModItem
    {
        //bool firstUpdate = true;

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases the sell price of your items");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 40;
            item.height = 40;
            item.value = 750000;
            item.rare = 2;
        }

        /*public override void UpdateEquip(Player player)
        {
            foreach (Item item in player.inventory)
            {
                item.value = (int)(item.value * 1.15f);
                Main.NewText(item.value);
            }
        }*/

        /*public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Main.NewText(firstUpdate);
            if (firstUpdate)
            {
                Main.NewText("This first update");
            }
            firstUpdate = false;
        }*/
    }
}