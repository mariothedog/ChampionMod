using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Projectiles
{
	public class StoneBoulder : ModProjectile
	{
        public override string Texture { get { return "Terraria/Projectile_" + ProjectileID.Boulder; } }
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("StoneBoulder");
		}

        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.Boulder);
			projectile.hostile = false;	
			projectile.timeLeft = 3600;		
	    }
		
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //Main.NewText(projectile.velocity);
		    projectile.velocity *= .9f;
		    return false;
		}
    }		
}
