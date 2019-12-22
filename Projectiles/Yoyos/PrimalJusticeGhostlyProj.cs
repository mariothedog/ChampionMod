using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Yoyos
{
    public class PrimalJusticeGhostlyProj : ModProjectile
    {
        public override string Texture { get { return "ChampionMod/Projectiles/Yoyos/PrimalJusticeProj"; } }

        public override void SetDefaults()
        {
            projectile.width = 15;
            projectile.height = 15;
            projectile.timeLeft = 3;
        }

        public override void AI()
        {
            projectile.alpha = (int)(1f / projectile.timeLeft * 255); // Fade Effect
        }
    }
}