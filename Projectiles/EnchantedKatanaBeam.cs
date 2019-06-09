using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class EnchantedKatanaBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.EnchantedBeam);
            aiType = ProjectileID.EnchantedBeam;
        }

        public override Color? GetAlpha (Color lightColor)
        {
            return Color.White;
        }
    }
}