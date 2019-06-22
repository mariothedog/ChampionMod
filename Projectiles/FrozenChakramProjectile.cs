using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class FrozenChakramProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			aiType = ProjectileID.EnchantedBoomerang;

            projectile.width = 40;
            projectile.height = 40;
            projectile.scale = 0.8f;

            drawOffsetX = -10;
            drawOriginOffsetY = -10;
		}
    }
}