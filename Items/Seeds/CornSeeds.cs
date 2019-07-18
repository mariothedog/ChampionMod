using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Seeds
{
    class CornSeeds : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.maxStack = 99;
            item.autoReuse = true;
            item.useTime = 10;
            item.useAnimation = 15;
            item.consumable = true;
            item.createTile = mod.TileType("CornCrop");
            item.useStyle = 1;
            item.placeStyle = 0;
            item.value = 80; // 16 copper like the vanilla seeds
            item.useTurn = true;
        }
    }
}