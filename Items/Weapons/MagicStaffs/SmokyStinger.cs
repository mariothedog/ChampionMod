using ChampionMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.MagicStaffs
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
			item.width = 36;
			item.height = 36;
			item.useTime = 47;
			item.useAnimation = 50;
			item.useStyle = 5;
			item.knockBack = 1;
            item.value = 6000; // 5 is 1 copper
			item.UseSound = SoundID.Item20;
            item.shoot = mod.ProjectileType("SporeCloud");
            item.shootSpeed = 3f;
			item.autoReuse = false;
		}

		//public override void AddRecipes()
		//{
			//ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(ItemID.Vine, 2);
            //recipe.AddIngredient(ItemID.Stinger, 5);
            //recipe.AddIngredient(ItemID.RichMahogany, 15);
			//recipe.AddTile(TileID.Anvils);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		//}
    }
}