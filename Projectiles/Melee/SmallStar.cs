using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Melee
{
    public class SmallStar : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.FallingStar);
			projectile.penetrate = 1;
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Player player = Main.player[projectile.owner];

            for (int i = 0; i < 8; i++)
            {
                Dust.NewDust(projectile.position, 30, 30, 62, player.direction, 0f, 150, new Color(255, 251, 0), 1.5f);
            }

            return true; // Kill projectile
        }
    }
}
