using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ChampionMod.Projectiles
{
    public class IchorthrowerProjectile : ModProjectile // Dust not done
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
            Lighting.AddLight(projectile.Center, 0.2f, 0.8f, 0.1f);

            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }

            if (projectile.ai[0] > 12f) // defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)
                {
                    Dust dust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 167, projectile.velocity.X, projectile.velocity.Y, 130, new Color(179,255,0), 3.1f)];
                    dust.noGravity = true;
                    
                    if (Main.rand.Next(7) == 0)
                    {
                        Dust dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 167, projectile.velocity.X, projectile.velocity.Y, 130, new Color(179,255,0), 1.2f)];
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
            target.AddBuff(BuffID.CursedInferno, 1200);
        }
 
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}