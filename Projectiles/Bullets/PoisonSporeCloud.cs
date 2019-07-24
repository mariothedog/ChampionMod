using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Bullets
{
    public class PoisonSporeCloud : ModProjectile
    {
        public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.SporeCloud; } }

        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 5;
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SporeCloud);
            aiType = ProjectileID.SporeCloud;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            // Apply poison for 7 seconds
            target.AddBuff(BuffID.Poisoned, 420);
        }
    }
}