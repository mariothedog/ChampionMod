﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Spears
{
    public class FarmerPitchforkProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.penetrate = -1;
            projectile.alpha = 0;

            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

        public float MovementFactor
        {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        public override void AI()
        {
            NPC projOwner = Main.npc[ChampionMod.farmer];

            projectile.ai[1] += 1f;

            projectile.direction = projOwner.direction;

            projectile.position.X = projOwner.Center.X - (float)(projectile.width / 2);
            projectile.position.Y = projOwner.Center.Y - (float)(projectile.height / 2);
            projectile.position += projectile.velocity * 25;

            if (MovementFactor == 0f) // When initially thrown out, the ai0 will be 0f.
            {
                MovementFactor = 2.4f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] >= 30) // Make the spear move back.
            {
                MovementFactor -= 1.8f;
            }
            else // Otherwise, increase the movement factor.
            {
                MovementFactor += 1.5f;
            }

            projectile.position += projectile.velocity * MovementFactor;

            if (projectile.ai[1] >= 50)
            {
                projectile.Kill();
            }

            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }

            ChampionMod.farmerProjectileRotation = MathHelper.ToDegrees(projectile.rotation);
        }

        // This code is taken from how vanilla draws projectiles from aiStyle 19
        // I couldn't use aiStyle 19 in this because in the aiStyle 19 code it requires a player which the farmer is not
        // This is needed so the hitbox isn't weird
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Color color26 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));

            Vector2 zero = Vector2.Zero;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            if (projectile.spriteDirection == -1)
            {
                zero.X = (float)Main.projectileTexture[projectile.type].Width;
            }

            Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], new Vector2(projectile.position.X - Main.screenPosition.X + (float)(projectile.width / 2), projectile.position.Y - Main.screenPosition.Y + (float)(projectile.height / 2) + projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle(0, 0, Main.projectileTexture[projectile.type].Width, Main.projectileTexture[projectile.type].Height), projectile.GetAlpha(color26), projectile.rotation, zero, projectile.scale, spriteEffects, 0f);

            return false;
        }
    }
}