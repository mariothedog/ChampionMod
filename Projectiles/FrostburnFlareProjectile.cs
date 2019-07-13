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
        bool hittingBlock = false;
        int hittingTimer = 0; // This is so the flare sinks under the block slightly without the hitbox changing like the original flare

        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.width = 6;
            projectile.height = 6;
            projectile.ignoreWater = true;
            //projectile.aiStyle = 33;
            projectile.penetrate = -1;
            projectile.timeLeft = 36000;
            //projectile.aiStyle = -1;
            //projectile.aiStyle = ProjectileID.Flare;
            //projectile.CloneDefaults(ProjectileID.Flare);
            //aiType = ProjectileID.Flare;

            //drawOffsetX = 15;

            //drawOriginOffsetX = -13;

            //drawOriginOffsetY = -20; //check

            drawOriginOffsetY = -10;
        }

        public override void AI()
        {
            if (!hittingBlock) // So the rotation is frozen and it doesn't fall in slightly when the flare hits the ground
            {
                projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Rotate sprite

                projectile.velocity.Y += 0.04f; // Gravity
            }
            else
            {
                hittingTimer += 1;
            }

            //Vector2 dustVelocity = Vector2.Normalize(new Vector2(projectile.velocity.X, projectile.velocity.Y));

            //Dust dust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), 1, 1, 197, 0, 0, 130, default(Color))];
            Dust dust = Terraria.Dust.NewDustPerfect(projectile.position, 197);
            dust.noGravity = true;
            //dust.velocity = dustVelocity;

            /*if (Main.rand.NextFloat() < 1f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Terraria.Dust.NewDustPerfect(position, 197, new Vector2(10f, 0f), 0, new Color(255, 255, 255), 1.842105f);
                dust.noGravity = true;
            }*/





            //dust.velocity.Y *= 1.2f;

            /*if (Main.rand.Next(7) == 0)
            {
                Dust dust2 = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 197, projectile.velocity.X, projectile.velocity.Y, 130, default(Color))];
                dust2.velocity *= 0.3f;
            }*/

            //projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Rotate sprite

            //projectile.velocity.Y += 0.04f; // Gravity
        }

        /*public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Rotate sprite

            Lighting.AddLight(projectile.position, 0f, 0.3f, 0f); // Green Light
        }*/

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            hittingBlock = true;

            /*for (int d = 0; d < 50; d++)
            {
                Terraria.Dust.NewDust(projectile.position, 30, 30, 148, 0f, 0f, 0, new Color(255,255,255), 1f);
            }*/

            //projectile.velocity = new Vector2(0, 1);

            /*projectile.velocity.X = 0;

            if (hittingTimer >= 1)
            {
                projectile.velocity.Y = 0;
            }
            else
            {
                if (projectile.velocity.Y == 0)
                {
                    projectile.velocity.Y = oldVelocity.Y;
                }
            }*/

            projectile.velocity = Vector2.Zero;

            return false; // Doesn't kill the flare
        }
    }
}