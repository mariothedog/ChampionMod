using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Magic
{
    public class BlueOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.friendly = true;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.width = 14;
            projectile.height = 14;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            // So the projectile faces the correct way
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.75f;
            //projectile.rotation = 0.79f * projectile.direction;
            
            // Projectile arcs slightly
            projectile.velocity.Y += 0.01f;

            projectile.frameCounter++;
            if (projectile.frameCounter > 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 3;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust.NewDust(projectile.position, 30, 30, 13, 0f, 0f, 0, new Color(0, 192, 255), 1.3f);
            }
        }
    }
}