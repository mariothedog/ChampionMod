using Microsoft.Xna.Framework; 
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons
{
	public class DualFlareshot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dual Flareshot");
		}

		public override void SetDefaults()
		{
			item.damage = 12;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 21;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 6;
			item.value = 1;
			item.rare = 2;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; 
			item.useAmmo = AmmoID.Flare;
			item.shootSpeed = 6f;
			item.holdStyle = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FlareGun, 2);
			recipe.AddRecipeGroup("Wood", 10);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; 
		}

		//public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
		//{
		//}

		public override Vector2? HoldoutOffset() // Handle is a bit off without this
		{
			return new Vector2(-3, 0);
		}

		int test = 1;
		public override void HoldItem(Player player) {
            //if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0) {
			// Position(Vector2), Width(int), Height(int), Type(int)
			Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, test);
			//}
			Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
			Lighting.AddLight(position, 1f, 1f, 1f);

			if (Main.rand.Next(150)==0)
			{
				Main.NewText(test);
				test++;
			}

            if (player.itemAnimation <= 0) // If not shooting
            {
                player.itemLocation.Y -= 17;

                if (player.direction == 1) // If facing right
                {
                    player.itemLocation.X -= 46;
                }
                else // If facing left
                {
                    player.itemLocation.X += 4;
                }
            }
		}
	}
}