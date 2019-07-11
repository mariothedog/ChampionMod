using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class FrostburnFlareProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.width = 6;
            projectile.height = 6;
            projectile.ignoreWater = true;
            //projectile.aiStyle = 33;
            projectile.maxPenetrate = -1;
            projectile.timeLeft = 36000;
            //projectile.aiStyle = -1;
            //projectile.aiStyle = ProjectileID.Flare;
            //projectile.CloneDefaults(ProjectileID.Flare);
            //aiType = ProjectileID.Flare;

            drawOffsetX = 15;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Rotate sprite
        }

        /*public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Rotate sprite

            Lighting.AddLight(projectile.position, 0f, 0.3f, 0f); // Green Light
        }*/

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            for (int d = 0; d < 50; d++)
            {
            Terraria.Dust.NewDust(projectile.position, 30, 30, 148, 0f, 0f, 0, new Color(255,255,255), 1f);
            }

            return false; // Doesn't kill the flare
        }
    }
}
