using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Tools
{
	public class RoyalPickaxe : ModItem
	{
		public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("It's really slimey");
		}

		public override void SetDefaults()
        {
			item.damage = 6;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 10;
			item.pick = 220;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 15000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			
			recipe.AddIngredient(mod.ItemType("KingsGel"), 5);
			recipe.AddRecipeGroup("ChampionMod:Tier3Bars", 12);
			recipe.AddIngredient(ItemID.Gel, 3);
			recipe.AddTile(TileID.Solidifier);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
        {
			if (Main.rand.NextBool(10))
            {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 33);
			}
		}
	}
}