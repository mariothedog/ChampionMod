using System;
using Terraria;
using Terraria.ModLoader;

namespace SingleSwordMod.Projectiles.Minions
{
    public abstract class BunnyMinion : ModProjectile
    {
        public override void AI()
        {
            CheckActive();
            Behavior();
        }

        public abstract void CheckActive();

        public abstract void Behavior();

        /*public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.immune[projectile.owner] = 6;
        }*/

        public override bool MinionContactDamage()
        {
            return true;
        }
    }
}