using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
	public class FrostStar : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("FrostStar");
		}

		public override void SetDefaults() {
			item.CloneDefaults(ProjectileID.FallingStar);
			projectile.penetrate = 1; 
		}
  }
}
