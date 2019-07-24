using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class FrosthrowerProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 125;
            projectile.extraUpdates = 3;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0f, 0.6f, 1f);

            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }

            if (projectile.ai[0] > 12f) // defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)
                {
                    Dust dust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 197, projectile.velocity.X, projectile.velocity.Y, 130, default(Color), 3f)];
                    dust.noGravity = true;

                    if (Main.rand.Next(7) == 0)
                    {
                        Dust dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 197, projectile.velocity.X, projectile.velocity.Y, 130, default(Color))];
                        dust2.velocity *= 0.3f;
                    }
                }
            }
            else
            {
                projectile.ai[0] += 1f;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 1200);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}