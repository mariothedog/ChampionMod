using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Ranged.Guns
{
	public class SnowballSledgeshot : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 5;
			item.ranged = true;
			item.noMelee = true;
			item.width = 40;
			item.height = 20;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.knockBack = 5;
			item.value = 100000;
			item.rare = 1;
			item.UseSound = SoundID.Item11;
			item.autoReuse = false;
			item.shoot = 10;
			item.shootSpeed = 12f;
			item.useAmmo = AmmoID.Snowball;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SnowballCannon);
            recipe.AddRecipeGroup("ChampionMod:Tier1Bars", 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 4 + Main.rand.Next(2);
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));

				Vector2 dir = Vector2.Normalize(new Vector2(speedX, speedY));
				Vector2 offset = dir * 40;
				if (Collision.CanHit(position, 0, 0, position + offset, 0, 0))
				{
					position += offset;
				}
				
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
		}

		public override Vector2? HoldoutOffset()
		{
		  return new Vector2(-2, -8);
		}
	}
}