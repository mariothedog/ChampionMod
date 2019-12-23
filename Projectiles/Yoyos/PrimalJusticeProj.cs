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

            // Afterimage
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[projectile.type] = 0; // The recording mode
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
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}