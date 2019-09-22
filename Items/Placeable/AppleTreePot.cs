using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChampionMod.Items.Placeable
{
    class AppleTreePot : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Completely Legal.");
        }

        public override void SetDefaults()
        {
            item.width = 12;
            item.height = 12;
            item.maxStack = 999;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType("AppleTreePotTile");
        }
    }
}
