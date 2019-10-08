using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ChampionMod.Projectiles.Flamethrowers
{
    public class MegaMelterProjectile : ModProjectile
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
            Lighting.AddLight(projectile.Center, 1f, 1f, 1f);

            if (projectile.timeLeft > 125)
            {
                projectile.timeLeft = 125;
            }

            if (projectile.ai[0] > 12f) // defines where the flames starts
            {
                if (Main.rand.Next(3) == 0)
                {
                    int dustType = 0;
                    float dustSize = 4.5f;
                    float smallDustSize = 1.2f;
                    Color dustColour = new Color();
                    switch (Main.rand.Next(5))
                    {
                        case 0:
                            dustType = 6; // Flamethrower dust
                            dustSize = 1;
                            smallDustSize = 1;
                            break;
                        case 1:
                            // This is being repeated so there is a bit more fire
                            dustType = 6; // Flamethrower dust
                            dustSize = 1.2f;
                            smallDustSize = 1.1f;
                            break;

                        case 2:
                            dustType = 197; // Frosthrower dust
                            dustSize = 3;
                            break;
                        case 3:
                            dustType = 75; // Cursedthrower dust
                            dustColour = new Color(179,255,0);
                            dustSize = 4.5f;
                            smallDustSize = 1.2f;
                            break;
                        case 4:
                            dustType = 6; // Ichorthrower dust
                            dustColour = new Color(255,200,0);
                            dustSize = 4.5f;
                            smallDustSize = 1.2f;
                            break;
                    }

                    Dust dust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X, projectile.velocity.Y, 130, dustColour, dustSize)];
                    dust.noGravity = true;
                    
                    if (Main.rand.Next(7) == 0)
                    {
                        Dust dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, dustType, projectile.velocity.X, projectile.velocity.Y, 130, dustColour, smallDustSize)];
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
            target.AddBuff(BuffID.OnFire, 2400);
            target.AddBuff(BuffID.Frostburn, 1200);
            target.AddBuff(BuffID.Ichor, 1200);
            target.AddBuff(BuffID.CursedInferno, 1200);
        }
 
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            return false;
        }
    }
}