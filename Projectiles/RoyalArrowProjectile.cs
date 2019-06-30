using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
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

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(0, projectile.position);

            return true; // To kill the projectile as normal
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 1200, false); // Slimed debuff for 20 seconds
        }
    }
}
