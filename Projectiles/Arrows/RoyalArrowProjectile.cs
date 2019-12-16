using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Arrows
{
    public class RoyalArrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true; // So it damages hostile npcs
            projectile.penetrate = 2; // How many npcs it will go through
            projectile.width = 8;
            projectile.height = 8;
            projectile.ignoreWater = true;
            projectile.aiStyle = 1; // arrow ai
        }

        public override void Kill(int timeLeft) // Since it is "Kill" it has the dust when it hits an enemy or a tile
        {
            // Gold dust
            for (int i = 0; i < 15; i++)
            {
                Dust.NewDust(projectile.position, 30, 30, 10, 0f, 0f, 0, new Color(255,255,255));
            }

            // Hit Sound
            Main.PlaySound(0, projectile.position);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 1200, false); // Slimed debuff for 20 seconds
        }
    }
}