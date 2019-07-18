using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
	public class StoneBoulder : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("StoneBoulder");
		}

      public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.Boulder);
    }
}
