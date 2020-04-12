using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Magic.MagicStaffs
{
	public class AcornStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Acorn Staff");
            Item.staff[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.damage = 6;
            item.magic = true;
			item.noMelee = true;
            item.mana = 2;
			item.width = 36;
			item.height = 36;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = 5;
			item.knockBack = 1;
            item.value = 150; // 5 is 1 copper
			item.UseSound = SoundID.Item20;
            item.shoot = mod.ProjectileType("Acorn");
            item.shootSpeed = 6f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 10);
            recipe.AddIngredient(ItemID.Acorn, 8);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}