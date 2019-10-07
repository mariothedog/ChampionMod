using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class VerdantBlade : ModItem
	{
		public override void SetDefaults()
        {
			item.damage = 5;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 2.5f;
            item.value = 1000;
			item.rare = 0;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("VerdantLeaf"), 10);
            recipe.AddRecipeGroup("Wood", 5);
			recipe.AddTile(TileID.LivingLoom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}