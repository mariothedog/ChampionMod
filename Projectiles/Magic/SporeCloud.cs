using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Magic 
{
	public class SporeCloud : ModProjectile 
	{
		public override void SetStaticDefaults() {
			ProjectileID.Sets.Homing[projectile.type] = true;
		}
		public override void SetDefaults()
		{
			projectile.aiStyle = 51;
			projectile.friendly = true;
			projectile.magic = true;
            projectile.tileCollide = false;
            projectile.penetrate = 0;
            projectile.timeLeft = 1000;
            projectile.width = 34;
            projectile.height = 34;
            projectile.ignoreWater = true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit){
			if (Main.rand.NextBool()){
				target.AddBuff(BuffID.Poisoned, 60);
			}
		}
	}
}