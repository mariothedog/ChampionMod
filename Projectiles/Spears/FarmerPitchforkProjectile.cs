using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Spears
{
    public class FarmerPitchforkProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.alpha = 0;

            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

        public float movementFactor
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        public override void AI()
        {
            projectile.ai[1] += 1f;

            NPC projOwner = Main.npc[ChampionMod.farmer];

            projectile.direction = projOwner.direction;
            projectile.position.X = projOwner.Center.X - (float)(projectile.width / 2);
            projectile.position.Y = projOwner.Center.Y - (float)(projectile.height / 2);

            // As long as the player isn't frozen, the spear can move
            if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
            {
                movementFactor = 1.9f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] % 600 == 0)
            {
                movementFactor -= 1.3f;
            }
            else // Otherwise, increase the movement factor
            {
                movementFactor += 1f;
            }

            projectile.position += projectile.velocity * movementFactor;

            //Main.NewText(projectile.position);

            if (projectile.ai[1] >= 2400)
            {
                projectile.Kill();
            }

            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
        }
    }
}