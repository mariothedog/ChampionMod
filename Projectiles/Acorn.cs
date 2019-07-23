using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class Acorn : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.friendly = true; // So it doesn't damage you
            projectile.tileCollide = true;
            projectile.penetrate = 1; // how many npcs it will go through
            projectile.timeLeft = 200;
            projectile.width = 14;
            projectile.height = 14;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            // So the projectile faces the correct way
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 0.75f;
            
            // Projectile arcs slightly
            projectile.velocity.Y += 0.03f;
        }
    }
}