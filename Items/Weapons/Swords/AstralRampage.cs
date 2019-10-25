using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Swords
{
	public class AstralRampage : ModItem
	{
		public override void SetDefaults()
        {
			item.damage = 56;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 1;
			item.knockBack = 6;
            item.value = 750000;
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.shoot = mod.ProjectileType("AstralRampageBeam");
            item.shootSpeed = 14f;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("OrionsSword"));
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient(ItemID.Starfury);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
		}

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 target = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            float ceilingLimit = target.Y;
            if (ceilingLimit > player.Center.Y - 200f)
            {
                ceilingLimit = player.Center.Y - 200f;
            }
            for (int i = 0; i < 2; i++)
            {
                Vector2 pos = player.Center + new Vector2((-(float)Main.rand.Next(0, 401) * player.direction), -600f);
                pos.Y -= (100 * i);
                Vector2 heading = target - pos;
                if (heading.Y < 0f)
                {
                    heading.Y *= -1f;
                }
                if (heading.Y < 20f)
                {
                    heading.Y = 20f;
                }
                heading.Normalize();
                heading *= new Vector2(speedX, speedY).Length();
                float spdX = heading.X;
                float spdY = heading.Y + Main.rand.Next(-40, 41) * 0.02f;

                if (i == 0)
                {
                    Projectile.NewProjectile(pos.X, pos.Y, spdX, spdY, mod.ProjectileType("FrostStar"), damage / 2, knockBack, player.whoAmI, 0f, ceilingLimit);
                }
                else
                {
                    Projectile.NewProjectile(pos.X, pos.Y, spdX, spdY, mod.ProjectileType("FlameStar"), damage / 2, knockBack, player.whoAmI, 0f, ceilingLimit);
                }
                
            }

            damage /= 2;
            return true;
        }
    }
}