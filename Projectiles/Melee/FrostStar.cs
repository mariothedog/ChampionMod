using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Melee
{
	public class FrostStar : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("FrostStar");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.FallingStar);
			projectile.penetrate = 1; 
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 180);
        }
    }
}