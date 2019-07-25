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
            projectile.aiStyle = 19;//-1; // -1 so it uses the method AI()
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

        // It appears that for this AI, only the ai0 field is used!
        public override void AI()
        {
            projectile.ai[0] += 1f;

            NPC projOwner = Main.npc[projectile.owner]; //TODO GET npc.whoAmI
            //NPC projOwner = NPC.FindFirstNPC//Main.npc[farmer];

            //Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            //projOwner.heldProj = projectile.whoAmI;
            //projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = projOwner.Center.X - (float)(projectile.width / 2);
            projectile.position.Y = projOwner.Center.Y - (float)(projectile.height / 2);
            // As long as the player isn't frozen, the spear can move
            if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
            {
                movementFactor = 1.9f; // Make sure the spear moves forward when initially thrown out
                projectile.netUpdate = true; // Make sure to netUpdate this spear
            }
            /*if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
            {
                movementFactor -= 1.3f;
            }*/
            if (projectile.ai[0] >= 120)
            {
                movementFactor -= 1.3f;
                projectile.ai[0] = 0f;
            }
            else // Otherwise, increase the movement factor
            {
                movementFactor += 1f;
            }
            // Change the spear position based off of the velocity and the movementFactor
            projectile.position += projectile.velocity * movementFactor;
            // When we reach the end of the animation, we can kill the spear projectile

            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);

            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
        }
    }
}