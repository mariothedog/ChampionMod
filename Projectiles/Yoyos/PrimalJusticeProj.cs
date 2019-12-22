using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Yoyos
{
    public class PrimalJusticeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // The following sets are only applicable to a yoyo that uses aiStyle 99.
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 12f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 230f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14f;
        }

        public override void SetDefaults()
        {
            //projectile.CloneDefaults(ProjectileID.Kraken);
            //projectile.aiStyle = ProjectileID.Kraken;

            projectile.extraUpdates = 0;
            projectile.width = 15;
            projectile.height = 15;
            projectile.aiStyle = 99;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true; // For Crit
        }

        // Afterimage
        public override void AI()
        {
            Projectile.NewProjectile(projectile.Center, Vector2.Zero, mod.ProjectileType("PrimalJusticeGhostlyProj"), 0, 0, projectile.owner);
        }
    }
}