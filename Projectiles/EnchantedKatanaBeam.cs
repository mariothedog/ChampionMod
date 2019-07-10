using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class EnchantedKatanaBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.EnchantedBeam);
            aiType = ProjectileID.EnchantedBeam;
        }

        public override Color? GetAlpha (Color lightColor)
        {
            return Color.White;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Player player = Main.player[projectile.owner];

            for (int i = 0; i < 200; i++)
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

                Dust enchantedDust = Main.dust[Dust.NewDust(projectile.position, 20, 20, dustChoice, (float)(player.direction * 2), 0f, 150, default(Color), 1.3f)];
                //enchantedDust.velocity *= 0.2f;
            }

            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];

            for (int i = 0; i < 200; i++)
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

                Dust enchantedDust = Main.dust[Dust.NewDust(target.position, projectile.width, projectile.height, dustChoice, player.direction, 0f, 150, default(Color), 1.3f)];

                /*if (player.direction == 1) // Right
                {
                    Dust enchantedDust = Main.dust[Dust.NewDust(target.position, 20, 20, dustChoice, -1, 0f, 150, default(Color), 1.3f)];
                }
                else // Left
                {
                    Dust enchantedDust = Main.dust[Dust.NewDust(target.position, 20, 20, dustChoice, 1, 0f, 150, default(Color), 1.3f)];
                }*/
            }
        }
    }
}