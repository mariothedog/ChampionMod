using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            /*if (projectile.spriteDirection == 1)
            {
                projectile.position.X = projOwner.Center.X - (float)(projectile.width / 2) + 10;
            }
            else
            {
                projectile.position.X = projOwner.Center.X - (float)(projectile.width / 2);
            }*/

            projectile.position.X = projOwner.Center.X - (float)(projectile.width / 2);
            projectile.position.Y = projOwner.Center.Y - (float)(projectile.height / 2);

            //Main.NewText(projectile.position.X);

            if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
            {
                movementFactor = 1.9f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[1] >= 40) // Makes the spear move back
            {
                movementFactor -= 1.3f;
            }
            else // Otherwise, increase the movement factor
            {
                movementFactor += 1f;
            }

            //Main.NewText(movementFactor);
            //Main.NewText(projectile.velocity);

            projectile.position += projectile.velocity * movementFactor;

            if (projectile.ai[1] >= 80)
            {
                projectile.Kill();
            }

            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
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