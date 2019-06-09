using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles
{
    public class BayonetProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = -1; // -1 so it uses the method AI()
            projectile.penetrate = -1;
            projectile.alpha = 0;

            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

		public float movementFactor {
			get { return projectile.ai[0]; }
			set { projectile.ai[0] = value; }
		}

        // It appears that for this AI, only the ai0 field is used!
		public override void AI() {
			// Since we access the owner player instance so much, it's useful to create a helper local variable for this
			// Sadly, Projectile/ModProjectile does not have its own
			Player projOwner = Main.player[projectile.owner];
			// Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
			Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
			projectile.direction = projOwner.direction;
			projOwner.heldProj = projectile.whoAmI;
			projOwner.itemTime = projOwner.itemAnimation;
			projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
			projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
			// As long as the player isn't frozen, the spear can move
			if (!projOwner.frozen) {
				if (movementFactor == 0f) // When initially thrown out, the ai0 will be 0f
				{
					movementFactor = 2f; // Make sure the spear moves forward when initially thrown out
					projectile.netUpdate = true; // Make sure to netUpdate this spear
				}
				if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
				{
					movementFactor -= 1.4f;
				}
				else // Otherwise, increase the movement factor
				{
					movementFactor += 1.1f;
				}
			}
			// Change the spear position based off of the velocity and the movementFactor
			projectile.position += projectile.velocity * movementFactor;
			// When we reach the end of the animation, we can kill the spear projectile
			if (projOwner.itemAnimation == 0) {
				projectile.Kill();
			}
			// MathHelper.ToRadians(xx degrees here)
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);

            // So the projectile's sprite doesn't flip upside down when hitting towards the left
            projectile.spriteDirection = projectile.direction;
		}
    }
}