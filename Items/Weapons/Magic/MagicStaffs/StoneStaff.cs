using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Magic.MagicStaffs
{
	public class StoneStaff : ModItem
	{
		public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stone Staff");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
        {
			item.damage = 8;
			item.magic = true;
			item.mana = 12;
			item.width = 48;
			item.height = 58;
			item.useTime = 31;
		    item.useAnimation = 31;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 6;
			item.rare = 1;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("StoneBoulder");
			item.shootSpeed = 8f;
	    	}

		public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock, 20);
            recipe.AddRecipeGroup("Wood", 15);
     		recipe.AddIngredient(ItemID.IronBar, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}