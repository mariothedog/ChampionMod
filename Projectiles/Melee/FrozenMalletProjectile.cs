using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Melee
{
    public class FrozenMalletProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
			//projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);
            //aiType = ProjectileID.FruitcakeChakram; // Fruitcake Chakram doesn't have a dust
            //aiType = ProjectileID.PaladinsHammerFriendly;

            projectile.width = 34;
            projectile.height = 34;
            projectile.extraUpdates = 2;
            projectile.aiStyle = 3;
        }

        /*public override void AI()
        {
            if (Main.rand.NextFloat() < 0.8f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                dust = Main.dust[Dust.NewDust(projectile.position, 30, 30, 67, 0f, 0f, 0, new Color(255,255,255))];
                dust.noGravity = true;
            }
        }*/

        public override void AI()
        {
            if (projectile.ai[0] == 0f)
            {
                projectile.ai[1] += 1f;
                if (projectile.ai[1] >= 20f)
                {
                    projectile.ai[0] = 1f;
                    projectile.ai[1] = 0f;
                    projectile.netUpdate = true;
                }
            }
            else
            {
                projectile.tileCollide = false;
                float num49 = 15f;
                float num50 = 3f;

                Vector2 vector3 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num51 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector3.X;
                float num52 = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - vector3.Y;
                float num53 = (float)Math.Sqrt((double)(num51 * num51 + num52 * num52));
                if (num53 > 3000f)
                {
                    projectile.Kill();
                }
                num53 = num49 / num53;
                num51 *= num53;
                num52 *= num53;
                if (projectile.velocity.X < num51)
                {
                    projectile.velocity.X = projectile.velocity.X + num50;
                    if (projectile.velocity.X < 0f && num51 > 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X + num50;
                    }
                }
                else if (projectile.velocity.X > num51)
                {
                    projectile.velocity.X = projectile.velocity.X - num50;
                    if (projectile.velocity.X > 0f && num51 < 0f)
                    {
                        projectile.velocity.X = projectile.velocity.X - num50;
                    }
                }
                if (projectile.velocity.Y < num52)
                {
                    projectile.velocity.Y = projectile.velocity.Y + num50;
                    if (projectile.velocity.Y < 0f && num52 > 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y + num50;
                    }
                }
                else if (projectile.velocity.Y > num52)
                {
                    projectile.velocity.Y = projectile.velocity.Y - num50;
                    if (projectile.velocity.Y > 0f && num52 < 0f)
                    {
                        projectile.velocity.Y = projectile.velocity.Y - num50;
                    }
                }

                if (Main.myPlayer == projectile.owner)
                {
                    Rectangle rectangle = new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
                    Rectangle value2 = new Rectangle((int)Main.player[projectile.owner].position.X, (int)Main.player[projectile.owner].position.Y, Main.player[projectile.owner].width, Main.player[projectile.owner].height);
                    if (rectangle.Intersects(value2))
                    {
                        projectile.Kill();
                    }
                }
            }

            if (projectile.ai[0] == 0f)
            {
                Vector2 velocity = projectile.velocity;
                velocity.Normalize();
                projectile.rotation = (float)Math.Atan2((double)velocity.Y, (double)velocity.X) + 1.57f;
            }
            else
            {
                Vector2 vector5 = projectile.Center - Main.player[projectile.owner].Center;
                vector5.Normalize();
                projectile.rotation = (float)Math.Atan2((double)vector5.Y, (double)vector5.X) + 1.57f;
            }
        }
    }
}