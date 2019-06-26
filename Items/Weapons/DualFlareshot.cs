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
			item.useAnimation = 21;
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
            recipe.AddRecipeGroup("ChampionMod:Tier2Bars", 5);
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

		public override Vector2? HoldoutOffset() // Handle is a bit off without this
		{
			return new Vector2(-3, 0);
		}

		public override void HoldItem(Player player) {
            if (player.itemAnimation <= 0) // If not shooting (just holding)
            {
				// Dust location, loc = location
				Vector2 loc = new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir);

                player.itemLocation.Y -= 17;

				loc.Y += 4;

                if (player.direction == 1) // If facing right
                {
                    player.itemLocation.X -= 46;
					loc.X -= 4; // So it looks like the dust is coming out of the gun
                }
                else // If facing left
                {
                    player.itemLocation.X += 4;
					loc.X -= 2;
                }

				int flareDustType = 0; // So if you don't have a flare equipped it won't show the dust
				
				for (int i = 0; i < 4; i++) // Checks which flare comes first (to see which dust to use)
				{
					int slotType = player.inventory[54+i].type;
					if (slotType == 931)
					{
						flareDustType = 127;
						break;
					}
					else if (slotType == 1614)
					{
						flareDustType = 187;
						break;
					}
				}

                if (flareDustType != 0)
                {
                    Dust dust;
                    // Top hole dust
                    dust = Main.dust[Dust.NewDust(loc, 4, 4, flareDustType, 0f, 0f, 100, default(Color), 1.6f)];
                    dust.noGravity = true;
                    dust.velocity.Y -= 4f * player.gravDir;

                    // Bottom hole dust
                    loc.Y += 6; // So it comes out of the bottom hole
                    dust = Main.dust[Dust.NewDust(loc, 4, 4, flareDustType, 0f, 0f, 100, default(Color), 1.6f)];
                    dust.noGravity = true;
                    dust.velocity.Y -= 4f * player.gravDir;
                }

				// Orange lighting
				Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
				Lighting.AddLight(position, 1f, 0.3f, 0f);
            }
		}
	}
}