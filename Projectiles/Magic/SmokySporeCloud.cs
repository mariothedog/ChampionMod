using System;
using Microsoft.Xna.Framework;
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
			projectile.aiStyle = ProjectileID.SporeCloud;
            aiType = ProjectileID.SporeCloud;
			projectile.friendly = true;
			projectile.magic = true;
            projectile.tileCollide = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 60*25;
            projectile.width = 34;
            projectile.height = 34;
            projectile.ignoreWater = true;
            projectile.alpha = 0;
		}
        public override void AI()
        {
            projectile.ai[0] += 1f;
            if (projectile.ai[0] > 50f)
            {
                projectile.ai[0] = 25f;
                projectile.alpha += 20;
                if (projectile.alpha >= 255)
                {
                    projectile.Kill();
                }
            }
            if (++projectile.frameCounter >= 5)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 5)
                {
                    projectile.frame = 0;
                }
            }

            for (int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
                if (!npc.friendly)
                {
                    float shootToX = npc.position.X + npc.width * 0.5f - projectile.Center.X;
                    float shootToY = npc.position.Y - projectile.Center.Y;
                    float distance = (float)Math.Sqrt(shootToX * shootToX + shootToY * shootToY);

                    if (distance < 150f && !npc.friendly && npc.active)
                    {
                        distance = 3f / distance;

                        shootToX *= distance;
                        shootToY *= distance;

                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit){
			if (Main.rand.NextBool()){
				target.AddBuff(BuffID.Poisoned, 60);
			}
		}
	}
}