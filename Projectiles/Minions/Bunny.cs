using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Minions
{
    public class Bunny : BunnyAI
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 21; // First 7 for walking, next 7 for attacking, final 7 for flying
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true; //This is necessary for right-click targeting
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 31;
            projectile.height = 28;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1; // -1 so it doesn't disappear when it hits an enemy
            projectile.timeLeft = 18000;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            //inertia = 30f;
            ProjectileID.Sets.LightPet[projectile.type] = false;
            //Main.projPet[projectile.type] = true;
            //projectile.aiStyle = 11; // -5
            //projectile.type = 266;
        }

        public override void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
            if (player.dead)
            {
                modPlayer.Bunny = false;
            }
            if (modPlayer.BunnyMinion)
            {
                projectile.timeLeft = 2;
            }
        }

        /*public override void CreateDust() // For Lighting
        {
            Lighting.AddLight((int)(projectile.Center.X / 16f), (int)(projectile.Center.Y / 16f), 0.6f, 0.9f, 0.3f);
        }*/

        public override void SelectFrame(Vector2 vel)
        {
            projectile.frameCounter++; // Increment frameCounter by 1
            attackingTimer--;

            if (projectile.frameCounter >= 8) // This is used so the animation isn't super fast
            {
                projectile.frameCounter = 0; // Reset timer

                // Animation for if the bunny is flying
                if (vel.Y > 3) // If flying
                {
                    projectile.frame = (projectile.frame + 1) % 7;

                    if (projectile.frame < 15)
                    {
                        projectile.frame += 14;
                    }
                }
                else
                {
                    if (projectile.frame > 14)
                    {
                        projectile.frame -= 7;
                    }

                    if ((vel.X > 0.03 || vel.Y > 0.03) && !hitTile) // If moving and not hitting a tile
                    {
                        projectile.frame = (projectile.frame + 1) % 7; // Increase frame if it hits 7 then go back to 0
                    }
                    else
                    {
                        projectile.frame = (projectile.frame + 1) % 3; // So it only displays the idle animation when not moving
                    }

                    if (attackingTimer > 0)
                    {
                        projectile.frame += 7;
                    }
                }

                hitTile = false;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            attackingTimer = 200;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //Main.NewText("Minion hit a tile");
            //projectile.velocity.X = 0;
            //projectile.velocity.Y = 0;
            //oldVelocity.X = 0;
            //oldVelocity.Y = 0;
            //Main.NewText(projectile.velocity);
            //Main.NewText(oldVelocity);
            hitTile = true;
            return false;
        }
    }
}