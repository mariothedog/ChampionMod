using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Magic
{
    public class SmokySporeCloud : ModProjectile 
	{
        public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.SporeCloud; } }
        public override void SetStaticDefaults() {
			ProjectileID.Sets.Homing[projectile.type] = true;
			Main.projFrames[projectile.type] = 5;
		}

		public override void SetDefaults()
		{
            projectile.friendly = true;
			projectile.magic = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 60*25;
            projectile.width = 34;
            projectile.height = 34;
            projectile.ignoreWater = true;
            projectile.alpha = 0;
		}

        bool dead = false;
        public override void AI()
        {
            // Fade
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 50f || dead)
            {
                projectile.ai[0] = 25f;
                projectile.alpha += dead ? 30 : 20;
                if (projectile.alpha >= 255)
                {
                    projectile.Kill();
                }
            }

            // Animation
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 5)
                {
                    projectile.frame = 0;
                }
            }

            if (dead)
            {
                return;
            }

            // Homing delay
            projectile.ai[1] += 1f;
            if (projectile.ai[1] <= 10f)
            {
                return;
            }

            // Homing
            for (int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
                if (!npc.friendly && npc.type != NPCID.TargetDummy)
                {
                    float shootToX = npc.Center.X - projectile.Center.X;//npc.position.X + npc.width * 0.5f - projectile.Center.X;
                    float shootToY = npc.Center.Y - projectile.Center.Y;//npc.position.Y - projectile.Center.Y;
                    float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                    if (distance < 150f && !npc.friendly && npc.active)
                    {
                        distance = 3f / distance;

                        shootToX *= distance;
                        shootToY *= distance;

                        Vector2 shootTo = new Vector2(shootToX, shootToY);
                        Vector2 npcDir = Vector2.Normalize(new Vector2(shootToX, shootToY));
                        Vector2 originalDir = Vector2.Normalize(projectile.velocity);
                        Vector2 homingDir = (npcDir + originalDir * 7) / 8;
                        projectile.velocity = homingDir * shootTo.Length();
                    }
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            dead = true;
            projectile.damage = 0;
            projectile.knockBack = 0;

			if (Main.rand.NextBool())
            {
				target.AddBuff(BuffID.Poisoned, 60);
			}

            for (int i = 0; i < 15; i++)
            {
                Dust.NewDust(projectile.position, target.width, target.height, 74);
            }
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            dead = true;
            projectile.damage = 0;
            projectile.knockBack = 0;

            for (int i = 0; i < 15; i++)
            {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 74);
            }

            return base.OnTileCollide(oldVelocity);
        }
    }
}