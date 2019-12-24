using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Melee
{
	public class VileSpit : ModProjectile
	{
		public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.timeLeft = 500;
		}

        public override void AI()
        {
            projectile.ai[0] += 1f;

            if (projectile.ai[0] > 3f)
            {
                projectile.ai[0] = 3f;
            }

            Vector2 pos = new Vector2(projectile.position.X, projectile.position.Y + 2f);

            if (projectile.ai[0] == 2f)
            {
                Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 9, 1f, 0f);

                for (int i = 0; i < 20; i += 1)
                {
                    Dust dust = Main.dust[Dust.NewDust(pos, projectile.width, projectile.height, 18, 0f, 0f, 100, default, 1.8f)];
                    dust.velocity *= 1.3f;
                    dust.velocity += projectile.velocity;
                    dust.noGravity = true;
                }
            }

            for (int i = 0; i < 2; i += 1)
            {
                Dust dust = Main.dust[Dust.NewDust(pos, projectile.width, projectile.height, 18, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 80, default, 1.3f)];
                dust.velocity *= 0.3f;
                dust.noGravity = true;
            }

            projectile.rotation += 0.4f * (float)projectile.direction;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 9, 1f, 0f);

            for (int i = 0; i < 20; i += 1)
            {
                Dust dust = Main.dust[Dust.NewDust(projectile.Center, projectile.width, projectile.height, 18, 0f, 0f, 100, default, 1.8f)];
                dust.noGravity = true;
            }

            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 9, 1f, 0f);

            for (int i = 0; i < 20; i += 1)
            {
                Dust dust = Main.dust[Dust.NewDust(projectile.Center, projectile.width, projectile.height, 18, 0f, 0f, 100, default, 1.8f)];
                dust.noGravity = true;
            }
        }
    }
}