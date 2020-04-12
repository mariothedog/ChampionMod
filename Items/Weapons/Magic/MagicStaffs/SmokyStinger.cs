using ChampionMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Magic.MagicStaffs
{
	public class SmokyStinger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smoky Stinger");
            Item.staff[item.type] = true;
		}
		public override void SetDefaults()
		{
			item.damage = 15;
			item.rare = 2;
            item.magic = true;
			item.noMelee = true;
            item.mana = 22;
			item.width = 44;
			item.height = 44;
			item.useTime = 47;
			item.useAnimation = 47;
			item.useStyle = 5;
			item.knockBack = 1;
            item.value = 6000; // 5 is 1 copper - it's better practice to make a base number and multiply it by 5. e.g.: if you want 5 copper then do 5*5, if you want 10 silver then either do (10*100)*5 or 10000*5 or something similar
			item.UseSound = SoundID.Item20;
            item.shoot = mod.ProjectileType("SmokySporeCloud");
            item.shootSpeed = 3f;
			item.autoReuse = false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Vine, 2);
            recipe.AddIngredient(ItemID.Stinger, 5);
            recipe.AddIngredient(ItemID.RichMahogany, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}