using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Projectiles.Magic
{
	public class StoneBoulder : ModProjectile
	{
        int slowDownTimer = 0;

        public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.Boulder; } }
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Stone Boulder");
		}

        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.width = 31;
            projectile.height = 31;
			projectile.timeLeft = 100;
            projectile.aiStyle = 25;
            projectile.friendly = true;
            projectile.penetrate = 2;
	    }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            slowDownTimer += 1;
            if (slowDownTimer >= 4)
            {
                projectile.velocity *= 0.9f;
                slowDownTimer = 0;
            }

            return false;
		}

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 35; i++)
            {
                Dust dust;
                dust = Main.dust[Terraria.Dust.NewDust(projectile.position, 30, 30, 1, 0f, 0f, 0, new Color(255, 255, 255), 1.5f)];
                dust.noGravity = true;
            }
        }
    }		
}