using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Melee.OtherMelee
{
	public class TheThirdEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Always observant. Never lets its guard down.");
		}

		public override void SetDefaults()
        {
			item.damage = 48;
			item.melee = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = Item.sellPrice(0, 1, 0, 50); ;
			item.rare = 4;
            item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.shoot = mod.ProjectileType("TheThirdEyeProjectile");
			item.shootSpeed = 14f;
		}

		// Materials haven't been added so I'm leaving this out for now.
		/*public override void AddRecipes()
        {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
	}
}