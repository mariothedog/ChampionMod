using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Flares
{
    public class FrostburnFlareProjectile : ModProjectile
    {
        bool hittingBlock = false;
        int hitTimeLeft = 0; // The amount of time left when the flare has hit a tile

        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.width = 6;
            projectile.height = 6;
            projectile.ignoreWater = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 36000;

            drawOriginOffsetY = -8;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.position, 0f, 0.7f, 0.9f);

            if (!hittingBlock) // So the rotation is frozen and it doesn't fall in slightly when the flare hits the ground
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Rotate sprite

                projectile.velocity.Y += 0.04f; // Gravity
            }

            // Dust
            Dust dust = Terraria.Dust.NewDustPerfect(projectile.Center, 197, Vector2.Zero);
            dust.noGravity = true;

            if (dust.velocity == Vector2.Zero)
            {
                Vector2 dustVelocity = (projectile.rotation + MathHelper.Pi * 1.5f).ToRotationVector2() * -5;

                dust.velocity = dustVelocity;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!hittingBlock) // So it only assigns the variable the first time it hits the block
            {
                hitTimeLeft = projectile.timeLeft;
            }

            hittingBlock = true;

            // So it dips into the block slightly without having to change the hitbox
            if (hitTimeLeft - projectile.timeLeft >= 1)
            {
                projectile.velocity = Vector2.Zero;
            }
            else
            {
                projectile.velocity = oldVelocity; // old velocity so it doesn't look glitchy as it falls into the block
            }

            return false; // Doesn't kill the flare
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            // Inflicts the frostburn debuff the same way as the vanilla flares
            if (Main.rand.Next(3) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 600);
            }
            else
            {
                target.AddBuff(BuffID.Frostburn, 300);
            }
        }
    }
}