using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Melee
{
	public class VileSpit : ModProjectile
	{
		public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 22;
            projectile.friendly = true;
            projectile.hostile = false;
		}
    }
}