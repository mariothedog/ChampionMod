using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Items.Placeable
{
	class OverseerBanner : ModItem
    {
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Nearby players get a bonus against: Overseer");
		}

		public override void SetDefaults()
        {
			item.width = 10;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 1;
			item.value = Item.sellPrice(0, 0, 2, 0);
			item.createTile = mod.TileType("OverseerBannerTile");
		}
	}
}