using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Projectiles
{
    public class EpicLaser : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.friendly = true; // So it doesn't damage you
            projectile.tileCollide = true;
            projectile.penetrate = 2; // how many npcs it will penetrate
            projectile.timeLeft = 200;
            projectile.width = 40;
            projectile.height = 40;
            projectile.light = 0.75f;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            // So the projectile faces the correct way
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
        }
    }
}
