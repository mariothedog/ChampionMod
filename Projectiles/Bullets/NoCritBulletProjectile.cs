using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Bullets
{
    public class NoCritBulletProjectile : ModProjectile
    {
        public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.Bullet; } }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bullet);
            aiType = ProjectileID.Bullet;
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            crit = false;
        }
    }
}