using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class AlloyedBlade : ModItem
	{
		public override void SetDefaults()
        {
			item.damage = 34;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 5;
            item.value = 350000;
			item.rare = 4;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("BondedMultisword"));
            recipe.AddIngredient(ItemID.FalconBlade);
            recipe.AddRecipeGroup("ChampionMod:ShadowScales", 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}