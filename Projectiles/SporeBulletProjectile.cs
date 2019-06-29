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
            // Fume Effect (Projectile applies the poison)
            for (int d = 0; d < 15; d++)
            {
                Projectile.NewProjectile(projectile.position.X + Main.rand.Next(-20, 20), projectile.position.Y + Main.rand.Next(-20, 20), 0, 0, mod.ProjectileType("PoisonSporeCloud"), 1, 0, projectile.owner);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Fume Effect (Projectile applies the poison)
            for (int d = 0; d < 15; d++)
            {
                Projectile.NewProjectile(projectile.position.X + Main.rand.Next(-20, 20), projectile.position.Y + Main.rand.Next(-20, 20), 0, 0, mod.ProjectileType("PoisonSporeCloud"), 1, 0, projectile.owner);
            }

            // Effect and sound
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
            
			return true; // Kills bullet like normal
		}
    }
}
