using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Projectiles.Minions
{
    public abstract class BunnyAI : BunnyMinion
    {
        /*protected float idleAccel = 0.05f;
        protected float spacingMult = 1f;
        protected float viewDist = 300f;       //minion view Distance
        protected float chaseDist = 200f;       //how far the minion can go
        protected float chaseAccel = 6f;
        protected float inertia = 40f;
        protected float shootCool = 50f;       //how fast the minion can shoot
        protected float shootSpeed;
        protected int shoot;*/
        protected int attackingTimer = 0;
        protected bool hitTile = false;

        public virtual void CreateDust()
        {
        }

        public virtual void SelectFrame(float vel)
        {
        }

        public override void Behavior()
        {
            Player player = Main.player[projectile.owner];

            float dist = Vector2.Distance(projectile.Center, player.Center);
            projectile.velocity = projectile.DirectionTo(player.Center) * 5;
            Main.NewText(projectile.velocity);

            projectie.rotation = projectile.velocity.X/Math.Abs(projectile.velocity.X);
        }

        /*public override void Behavior()
        {
            Player player = Main.player[projectile.owner];
            float spacing = (float)projectile.width * spacingMult;
            //for (int k = 0; k < 1000; k++)
            //{
            //    Projectile otherProj = Main.projectile[k];
            //    if (k != projectile.whoAmI && otherProj.active && otherProj.owner == projectile.owner && otherProj.type == projectile.type && Math.Abs(projectile.position.X - otherProj.position.X) + Math.Abs(projectile.position.Y - otherProj.position.Y) < spacing)
            //    {
            //        if (projectile.position.X < Main.projectile[k].position.X)
            //        {
            //            projectile.velocity.X -= idleAccel;
            //        }
            //        else
            //        {
            //            projectile.velocity.X += idleAccel;
            //        }
            //        if (projectile.position.Y < Main.projectile[k].position.Y)
            //        {
            //            projectile.velocity.Y -= idleAccel;
            //        }
            //        else
            //        {
            //            projectile.velocity.Y += idleAccel;
            //        }
            //    }
            //}
            Vector2 targetPos = projectile.position;
            float targetDist = viewDist;
            bool target = false;
            projectile.tileCollide = true;
            if (player.HasMinionAttackTargetNPC) // If player has targetted an enemy (with right click)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                {
                    targetDist = Vector2.Distance(projectile.Center, targetPos);
                    targetPos = npc.Center;
                    target = true;
                }
            }
            else // If player hasn't targetted an enemy
            {
                for (int k = 0; k < 200; k++)
                {
                    NPC npc = Main.npc[k]; // Goes through each npc
                    if (npc.CanBeChasedBy(this, false))
                    {
                        float distance = Vector2.Distance(npc.Center, projectile.Center);
                        if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                        {
                            targetDist = distance;
                            targetPos = npc.Center;
                            target = true;
                        }
                    }
                }
            }

            //Main.NewText(Vector2.Distance(player.Center, projectile.Center)); // Send message in chat

            // Checks if the distance between the player and the minion is greater than 1000 (if target is true) or 500 (if target is false)
            if (Vector2.Distance(player.Center, projectile.Center) > (target ? 1000f : 500f)) // If target is true then 1000f is false then 500f
            {
                projectile.ai[0] = 1f; // projectile.ai is a way for storing information that isn't reset each tick

                projectile.netUpdate = true; // at the end of the tick when netUpdate is set to true, it updates its position, ai[] etc in multiplayer
                // certain calculations for projectiles have to be done on the client of the owner, and then that needs to be told to other clients and the server via netUpdate
                // things like bullets and arrows don't need it most of the time but minions and pets do
                // Be careful with netUpdate as setting it every tick can cause lag
            }
            // When projectile.ai[0] is 1 the minion is colliding with a tile
            // When projectile.ai[1] is 0 the minion is not targetting anything
            Main.NewText("AI 0: " + projectile.ai[0]);
            Main.NewText("AI 1: " + projectile.ai[1]);

            if (projectile.ai[0] == 1f) // If hitting tile
            {
                projectile.tileCollide = true;
            }
            if (target && projectile.ai[0] == 0f) // If targetting and not hitting tile
            {
                Vector2 direction = targetPos - projectile.Center;
                if (direction.Length() > chaseDist)
                {
                    direction.Normalize();
                    projectile.velocity = (projectile.velocity * inertia + direction * chaseAccel) / (inertia + 1);
                }
                else
                {
                    projectile.velocity *= (float)Math.Pow(0.97, 40.0 / inertia);
                }
            }
            else // If not targetting or hitting tile
            {
                // Controls the direction and slowing down of the minion based on distance from player

                if (!Collision.CanHitLine(projectile.Center, 1, 1, player.Center, 1, 1))
                {
                    projectile.ai[0] = 1f;
                }
                float speed = 6f;
                if (projectile.ai[0] == 1f)
                {
                    speed = 15f;
                }
                Vector2 center = projectile.Center;
                Vector2 direction = player.Center - center;
                projectile.ai[1] = 3600f;
                projectile.netUpdate = true;
                int num = 1;
                for (int k = 0; k < projectile.whoAmI; k++)
                {
                    if (Main.projectile[k].active && Main.projectile[k].owner == projectile.owner && Main.projectile[k].type == projectile.type)
                    {
                        num++;
                    }
                }
                direction.X -= (float)((10 + num * 40) * player.direction);
                direction.Y -= 70f;
                float distanceTo = direction.Length();
                if (distanceTo > 200f && speed < 9f)
                {
                    speed = 9f;
                }
                if (distanceTo < 100f && projectile.ai[0] == 1f && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                {
                    projectile.ai[0] = 0f;
                    projectile.netUpdate = true;
                }
                if (distanceTo > 2000f)
                {
                    projectile.Center = player.Center;
                }
                if (distanceTo > 48f)
                {
                    direction.Normalize();
                    direction *= speed;
                    float temp = inertia / 2f;
                    projectile.velocity = (projectile.velocity * temp + direction) / (temp + 1);
                }
                else
                {
                    projectile.direction = Main.player[projectile.owner].direction;
                    projectile.velocity *= (float)Math.Pow(0.9, 40.0 / inertia);
                }
            }
            
            projectile.rotation = projectile.velocity.X * 0.05f;
            SelectFrame(Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y));
            //Main.NewText(Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y));
            CreateDust();
            if (projectile.velocity.X > 0f)
            {
                projectile.spriteDirection = projectile.direction = -1;
            }
            else if (projectile.velocity.X < 0f)
            {
                projectile.spriteDirection = projectile.direction = 1;
            }
            if (projectile.ai[1] > 0f)
            {
                projectile.ai[1] += 1f;
                if (Main.rand.NextBool(3))
                {
                    projectile.ai[1] += 1f;
                }
            }
            if (projectile.ai[1] > shootCool)
            {
                projectile.ai[1] = 0f;
                projectile.netUpdate = true;
            }
            if (projectile.ai[0] == 0f)
            {
                if (target)
                {
                    if ((targetPos - projectile.Center).X > 0f)
                    {
                        projectile.spriteDirection = projectile.direction = -1;
                    }
                    else if ((targetPos - projectile.Center).X < 0f)
                    {
                        projectile.spriteDirection = projectile.direction = 1;
                    }
                    if (projectile.ai[1] == 0f)
                    {
                        projectile.ai[1] = 1f;
                        if (Main.myPlayer == projectile.owner)
                        {
                            Vector2 shootVel = targetPos - projectile.Center;
                            if (shootVel == Vector2.Zero)
                            {
                                shootVel = new Vector2(0f, 1f);
                            }
                            shootVel.Normalize();
                            shootVel *= shootSpeed;
                            int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, shootVel.X, shootVel.Y, shoot, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                            Main.projectile[proj].timeLeft = 300;
                            Main.projectile[proj].netUpdate = true;
                            projectile.netUpdate = true;
                        }
                    }
                }
            }
        }*/

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            fallThrough = false; // Can fall through platforms
            return true;
        }
    }
}