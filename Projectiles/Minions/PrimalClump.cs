using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Minions
{
    public class PrimalClump : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 5;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.netImportant = true;
            projectile.width = 31;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.minion = true;
            projectile.minionSlots = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 18000;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            ProjectileID.Sets.LightPet[projectile.type] = false;
        }

        public void CheckActive()
        {
            Player player = Main.player[projectile.owner];
            if (player.dead || !player.active)
            {
                player.ClearBuff(mod.BuffType("PrimalClumpBuff"));
            }
            if (player.HasBuff(mod.BuffType("PrimalClumpBuff")))
            {
                projectile.timeLeft = 2;
            }
        }

        public override void AI()
        {
            CheckActive();

            Behavior();

            Animate();
        }

        float speed = 8f;
        float inertia = 40f;
        public void Behavior()
        {
            Player player = Main.player[projectile.owner];

            // projectile.minionPos is its place in the summoned minion list - Needed so the minions don't stand in the same position
            float minionPositionOffsetX = (10 + projectile.minionPos * 40) * -player.direction;
            Vector2 idlePosition = player.Center + new Vector2(minionPositionOffsetX, -48);

            float distanceToIdlePosition = (idlePosition - projectile.Center).Length();

            float distanceFromTarget = 700f;
            Vector2 targetCenter = projectile.position;
            bool foundTarget = false;

            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                float between = Vector2.Distance(npc.Center, projectile.Center);
                if (between < 2000f)
                {
                    distanceFromTarget = between;
                    targetCenter = npc.Center;
                    foundTarget = true;
                }
            }

            if (!foundTarget)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy())
                    {
                        float between = Vector2.Distance(npc.Center, projectile.Center);
                        bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
                        bool inRange = between < distanceFromTarget;
                        bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
                        bool abovePlayer = player.Center.Y > npc.Center.Y;

                        if (((closest && inRange) || !foundTarget) && lineOfSight)
                        {
                            distanceFromTarget = between;
                            targetCenter = npc.Center;
                            foundTarget = true;
                        }
                    }
                }
            }

            Vector2 direction = Vector2.Normalize(idlePosition - projectile.Center);
            direction *= speed;
            projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
        }

        readonly int frameSpeed = 10; // Higher = Slower
        public void Animate()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= frameSpeed)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % Main.projFrames[projectile.type];
            }
        }
    }
}