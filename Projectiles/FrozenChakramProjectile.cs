using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Champion.Projectiles
{
    public class FrozenChakramProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.EnchantedBoomerang);
			aiType = ProjectileID.EnchantedBoomerang;
		}
    }
}