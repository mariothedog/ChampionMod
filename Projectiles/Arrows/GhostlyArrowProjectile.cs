using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Arrows
{
    public class GhostlyArrowProjectile : ModProjectile
    {
        int originalDamage;

        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.width = 8;
            projectile.height = 8;
            projectile.ignoreWater = true;
            projectile.aiStyle = 1;
        }

        public override void AI()
        {
            if (projectile.ai[1] == 0f)
            {
                projectile.Opacity = 0f;
                originalDamage = projectile.damage;
                projectile.damage = 0;
            }

            projectile.ai[1] = 1f;

            if (projectile.Opacity >= 0.1f)
            {
                projectile.damage = originalDamage;
            }

            if (projectile.Opacity < 0.5f)
            {
                projectile.Opacity += 0.02f;
            }
        }
    }
}