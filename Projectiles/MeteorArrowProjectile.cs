using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.Projectiles
{
    public class MeteorArrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true; // So it doesn't damage you
            projectile.tileCollide = true;
            projectile.penetrate = 2; // how many npcs it will go through
            projectile.width = 8;
            projectile.height = 8;
            //projectile.light = 0f;
            //projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
            projectile.aiStyle = 1;
            //aiType = ProjectileID.WoodenArrowFriendly;
            //drawOffsetX = 30;
            //drawOriginOffsetX = 30;
        }

        public override void AI()
        {
            // So the projectile faces the correct way
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) - 1.56f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }
    }
}
