using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons
{
	public class SnowballRifle : ModItem
	{
		public override void SetStaticDefaults() {
		   Tooltip.SetDefault("Great for snowball murder!");
		}

		public override void SetDefaults() {
			item.damage = 14;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 33;
			item.useAnimation = 33;
			item.useStyle = 5;
			item.knockBack = 7;
			item.value = 5;
			item.rare = 0;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 11f;
			item.useAmmo = AmmoID.Snowball;
			item.crit = 10; // 14 chance of crit
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SilverBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		/*public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 0) // Left Click
			{
				item.shoot = 10;
				item.useAnimation = 33;
				player.GetModPlayer<MyPlayer>().rightClick = false;
			}
			else // Right click
			{
				item.shoot = 0;
				item.useAnimation = 0;
			}
			return base.CanUseItem(player);
		}*/
	}
}