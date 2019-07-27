using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Bullets
{
    public class RoyalBulletProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.width = 2;
            projectile.height = 2;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            aiType = ProjectileID.Bullet;
			projectile.CloneDefaults(ProjectileID.Bullet);
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Slimed, 1200, false); // Slimed debuff for 20 seconds
        }
    }
}