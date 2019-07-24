using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Melee
{
    public class EnchantedKatanaBeam : ModProjectile
    {
        int timer = 0;

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.EnchantedBeam);
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45f); // Rotate sprite

            if (timer % 4 == 0)
            {
                projectile.scale = 1.1f;
            }
            else
            {
                projectile.scale = 1;
            }

            if (projectile.alpha > 0)
            {
                projectile.alpha -= 10;
            }

            if (Main.rand.Next(2) == 0) // Lowers amount of dust
            {
                int dustChoice;
                switch (Main.rand.Next(3))
                {
                    case 0:
                        dustChoice = 15;
                        break;
                    case 1:
                        dustChoice = 57;
                        break;
                    default:
                        dustChoice = 58;
                        break;
                }

                // Offset the dust
                Vector2 dustPosition = projectile.position;
                Vector2 offset = Vector2.Normalize(new Vector2(projectile.velocity.X, projectile.velocity.Y)) * -45;
                dustPosition += offset;

                // Create the dust
                Dust enchantedDust = Main.dust[Dust.NewDust(dustPosition, projectile.width, projectile.height, dustChoice, (Main.player[projectile.owner].direction*2), 0f, 150, default(Color), 1.3f)];
                enchantedDust.velocity *= 0.2f;
            }

            timer += 1;
        }

        public override Color? GetAlpha (Color lightColor)
        {
            return Color.White * ((255 - projectile.alpha) / 255f);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];

            for (int i = 0; i < 15; i++)
            {
                int dustChoice;
                switch (Main.rand.Next(3))
                {
                    case 0:
                        dustChoice = 15;
                        break;
                    case 1:
                        dustChoice = 57;
                        break;
                    default:
                        dustChoice = 58;
                        break;
                }

                Dust enchantedDust = Main.dust[Dust.NewDust(target.position, 1, 1, dustChoice, player.direction, 0f, 150, default(Color), 1.3f)];
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Player player = Main.player[projectile.owner];

            for (int i = 0; i < 15; i++)
            {
                int dustChoice;
                switch (Main.rand.Next(3))
                {
                    case 0:
                        dustChoice = 15;
                        break;
                    case 1:
                        dustChoice = 57;
                        break;
                    default:
                        dustChoice = 58;
                        break;
                }

                Dust enchantedDust = Main.dust[Dust.NewDust(projectile.position, 1, 1, dustChoice, player.direction, 0f, 150, default(Color), 1.3f)];
            }

            return true; // Kill projectile
        }
    }
}