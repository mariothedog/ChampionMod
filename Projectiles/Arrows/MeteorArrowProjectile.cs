using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Arrows
{
    public class MeteorArrowProjectile : ModProjectile
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

        public override void AI()
        {
            // The projectile rotation (so it faces the correct way) is automatically done as the arrow ai is used

            Terraria.Dust.NewDust(projectile.position, 30, 30, 55, 0f, 0f, 0, new Color(255,255,255), 1f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Explosive sound
            Main.PlaySound(SoundID.Item14, projectile.position);

            // Dust
            for (int d = 0; d < 50; d++)
            {
                Terraria.Dust.NewDust(projectile.position, 30, 30, 148, 0f, 0f, 0, new Color(255,255,255), 1f);
            }

            return true; // To kill the projectile as normal
        }
    }
}
