using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Balloon)]
    class LuckyCat : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases the sell price of your items");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 40;
            item.height = 40;
            item.value = 150000;
            item.rare = 2;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<MyPlayer>().hasLuckyCat = true;
        }
    }
}