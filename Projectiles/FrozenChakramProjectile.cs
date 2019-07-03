using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class FrozenChakramProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.ThornChakram);
			aiType = ProjectileID.FruitcakeChakram; // Fruitcake Chakram doesn't have a dust

            projectile.width = 34;
            projectile.height = 34;
            projectile.scale = 0.8f;

            drawOffsetX = -15;
            drawOriginOffsetY = -10;
		}

        public override void AI()
        {
            if (Main.rand.NextFloat() < 0.8f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                dust = Main.dust[Terraria.Dust.NewDust(projectile.position, 30, 30, 67, 0f, 0f, 0, new Color(255,255,255))];
                dust.noGravity = true;
            }
        }
    }
}