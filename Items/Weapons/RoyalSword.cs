using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons
{
	public class RoyalSword : ModItem
	{

		public override void SetDefaults()
		{
			item.damage = 20;
			item.melee = true;
			item.width = 40;
			item.height = 40;
            item.useTime = 23;
			item.useAnimation = 40;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 15000;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.useTurn = false;
			item.scale = 1.25f;
		}
		
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 9);
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Gel, 100);
			recipe.AddIngredient(mod.ItemType("KingsGel"), 1);
            recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}