using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Melee.Clubs
{
	public class BrumousBeater : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Who knew clouds had such a weight?");
		}

		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 40;
			item.height = 40;
            item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 25000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.useTurn = true;
			item.scale = 1.30f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Cloud, 50);
			recipe.AddRecipeGroup("ChampionMod:Tier2Broadswords");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}