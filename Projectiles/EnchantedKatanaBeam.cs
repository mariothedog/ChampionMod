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
        //public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.EnchantedBeam; } }

        public override void SetDefaults()
        {
            /*projectile.melee = true;
            projectile.friendly = true; // So it damages hostile npcs
            projectile.width = 16;
            projectile.height = 16;
            projectile.light = 0.2f;
            //projectile.alpha = 255;
            projectile.ignoreWater = true;
            projectile.aiStyle = 27;*/
            projectile.CloneDefaults(ProjectileID.EnchantedBeam);
            projectile.aiStyle = -1;
        }

        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.3f;

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
            drawOffsetX = 20;
            Dust enchantedDust = Main.dust[Dust.NewDust(projectile.position, 15, 15, dustChoice, (float)(projectile.direction * 2), 0f, 150, default(Color), 1.3f)];
            enchantedDust.velocity *= 0.2f;
        }

        /*public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Explosive sound
            Main.PlaySound(SoundID.Item14, projectile.position);

            // Dust
            for (int d = 0; d < 50; d++)
            {
                Terraria.Dust.NewDust(projectile.position, 30, 30, 148, 0f, 0f, 0, new Color(255,255,255), 1f);
            }

            return true; // To kill the projectile as normal
        }*/

        public override Color? GetAlpha (Color lightColor)
        {
            return Color.White;
        }
    }
}