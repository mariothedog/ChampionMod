using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Melee
{
    public class FrozenMalletProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.PaladinsHammerFriendly);
            aiType = ProjectileID.PaladinsHammerFriendly;

            projectile.width = 20;
            projectile.height = 20;
        }

        public override void AI()
        {
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] >= 7f)
            {
                projectile.localAI[0] = 1f;
                projectile.netUpdate = true;
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0, 0, mod.ProjectileType("FrozenMalletSnowflakeProjectile"), 10, 3, projectile.owner, 0f, 0f);
            }

            if (Main.rand.NextFloat() < 0.8f)
            {
                Dust dust;
                dust = Main.dust[Dust.NewDust(projectile.position, 30, 30, 67, 0f, 0f, 0, new Color(0, 167, 255))];
                dust.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 240);
        }
    }
}