using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class SporeBulletProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.width = 2;
            projectile.height = 2;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            aiType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f); // Rotate sprite

            Lighting.AddLight(projectile.position, 0f, 0.3f, 0f); // Green Light
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 420); // Poison enemy hit

            // Fume effect
            for (int d = 0; d < 50; d++)
            {
                Terraria.Dust.NewDust(target.position, 30, 30, 31, 0f, 0f, 0, new Color(159,255,0), 2.5f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Effect and sound
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);

			return true; // Kills bullet like normal
		}
    }
}
