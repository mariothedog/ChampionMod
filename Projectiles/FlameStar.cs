using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
	public class FlameStar : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Flame Star");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.FallingStar);
			projectile.penetrate = 1; 
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            // Add Onfire buff to the NPC for 1 second
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 180);
        }
    }
}
