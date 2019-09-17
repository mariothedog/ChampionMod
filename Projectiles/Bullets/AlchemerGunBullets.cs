using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Bullets
{
    class AlchemerGunBullets : ModProjectile
    {
        public int debuff = BuffID.OnFire; // Default
        public string type = "Blazing"; // Default

        public override string Texture { get { return $"ChampionMod/Projectiles/Bullets/{type}BulletProjectile"; } }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bullet);
            aiType = ProjectileID.Bullet;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(debuff, 1200, false);
        }
    }

    class BlazingBulletProjectile : AlchemerGunBullets {}

    class CorrosiveBulletProjectile : AlchemerGunBullets
    {
        public CorrosiveBulletProjectile()
        {
            debuff = BuffID.CursedInferno;
            type = "Corrosive";
        }
    }

    class AcidicBulletProjectile : AlchemerGunBullets
    {
        public AcidicBulletProjectile()
        {
            debuff = BuffID.Ichor;
            type = "Acidic";
        }
    }

    class DreadfulBulletProjectile : AlchemerGunBullets
    {
        public DreadfulBulletProjectile()
        {
            debuff = BuffID.Poisoned;
            type = "Dreadful";
        }
    }
}