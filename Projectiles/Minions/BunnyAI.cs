using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System.Collections.Generic;

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
        //protected int attackingTimer = 0;
        //protected bool hitTile = false;
        //protected bool aboveGround = false;
        //protected bool noBlockRight = true;
        //protected bool noBlockLeft = true;
        //protected int jumpDelayTimer = 200; // Timer till the next time the bunny can jump
        //protected int jumpTimer = 0; // Timer for when the bunny is jumping and when to stop

        public virtual void CreateDust()
        {
        }

        public virtual void SelectFrame()
        {
        }

        //Vector2 targetPos; // Target position

        //public int vMax = 6; // Maximum velocity of the minion
        //public float vAccel = 0.2f; // Maximum acceleration of the minion

        // There are 2 separate variables for this because it makes the moving transition smoother
        //public float tVel = 0; // Target velocity
        //public float vMag = 0; // Velocity magnitude (speed)

        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;

        private const int State_Waiting = 0; // Waiting for an enemy
        private const int State_Far = 1; // Player is too far away
        public const int State_Notice = 2; // Found an enemy
        private const int State_BlockRight = 3; // Block to the right that needs to be jumped over
        private const int State_BlockLeft = 4; // Block to the left that needs to be jumped over
        public const int State_Flying = 5; // Minion is flying in the air

        public float AI_State
        {
            get => projectile.ai[AI_State_Slot];
            set => projectile.ai[AI_State_Slot] = value;
        }

        public float AI_Timer
        {
            get => projectile.ai[AI_Timer_Slot];
            set => projectile.ai[AI_Timer_Slot] = value;
        }

        NPC enemy = null;

        // These 2 variables are needed so when the minion is jumping over the block it can determine how big the "block tower" is so it knows how high it needs to jump
        int blockLocationX;
        int blockLocationY;

        bool jumping = false; // If the minion is jumping or flying

        public override void Behavior()
        {
            Player player = Main.player[projectile.owner]; // Get player that summoned the minion

            //Vector2 offset = player.direction == 1 ? new Vector2(90, 0) : new Vector2(-90, 0);
            Vector2 offset = player.velocity == Vector2.Zero ? Vector2.Zero : Vector2.Normalize(player.velocity) * 70;
            Vector2 directionToPlayer = projectile.DirectionTo(player.Center + offset); // Get the direction to the player
            float dist = Vector2.Distance(projectile.Center, player.Center + offset);

            if (AI_State == State_Waiting)
            {
                // TO DO IF PLAYER HAS RIGHT CLICK TARGET, DON'T HURT TARGET DUMMIES, ANIMATION, ATTACKING, FLYING = NO GRAVITY
                for (int k = 0; k < 200; k++) // Finds npc to attack
                {
                    NPC npc = Main.npc[k];
                    if (npc.CanBeChasedBy(projectile, false))
                    {
                        if (Vector2.Distance(npc.Center, projectile.Center) < 300 && Collision.CanHitLine(projectile.position + new Vector2(0, -32), projectile.width, projectile.height, npc.position, npc.width, npc.height)) // Put the position of the minion 32 pixels up on the Collision.CanHitLine method because high ground = better visibility for minion
                        {
                            enemy = npc;
                            AI_State = State_Notice;
                        }
                    }
                }

                Tile tileBelow = Main.tile[(int)player.Bottom.X / 16, (int)player.Bottom.Y / 16 + 1];
                if (!(Main.tileSolid[tileBelow.type] && tileBelow.active()))
                {
                    jumping = true;
                    AI_State = State_Flying;
                }

                // Checks if the minion is too far away from the player
                // If the minion has found an enemy to attack then the distance that it can be from the player will be increased
                if (dist > (enemy == null ? 700 : 1200))
                {
                    AI_State = State_Far;
                }
                else
                {
                    if (enemy == null) // If the minion hasn't already found an enemy
                    {
                        projectile.direction = directionToPlayer.X > 0 ? -1 : 1; // Used for switching the sprite direction (in SelectFrame)

                        int multi = 5;

                        if (dist <= 20)
                        {
                            multi = 1;
                        }
                        else if (dist <= 40)
                        {
                            multi = 2;
                        }
                        else if (dist <= 60)
                        {
                            multi = 3;
                        }
                        else if (dist <= 80)
                        {
                            multi = 4;
                        }

                        projectile.velocity = directionToPlayer * multi;
                    }

                    BlockJump();
                }
            }
            else if (AI_State == State_Far)
            {
                // Teleport to player
                projectile.position = player.Center;

                Tile tileBelow = Main.tile[(int)player.Bottom.X / 16, (int)player.Bottom.Y / 16 + 1];
                if (Main.tileSolid[tileBelow.type] && tileBelow.active())
                {
                    jumping = false;
                    AI_State = State_Waiting;
                }
                else
                {
                    jumping = true;
                    AI_State = State_Flying;
                }
            }
            else if (AI_State == State_BlockRight || AI_State == State_BlockLeft)
            {
                jumping = true;

                int height = 1; // Height of the "block tower" that needs to be jumped over, set to 1 since if the bunny is in projectile AI_State then there is at least 1 block already
                for (int y = 1; y < 4; y++)
                {
                    Tile tile = Main.tile[blockLocationX, blockLocationY - y];
                    if (Main.tileSolid[tile.type] && tile.active())
                    {
                        height += 1;
                    }
                    else
                    {
                        break;
                    }
                }

                if (AI_State == State_BlockRight)
                {
                    //projectile.velocity = new Vector2(4, -height - 1);
                    projectile.velocity.Y = -height - 1;
                    if (projectile.velocity.X == 0) projectile.velocity.X = 4;

                    projectile.direction = -1;
                }
                else
                {
                    //projectile.velocity = new Vector2(-4, -height - 1);
                    projectile.velocity.Y = -height - 1;
                    if (projectile.velocity.X == 0) projectile.velocity.X = -4;

                    projectile.direction = 1;
                }

                if (AI_Timer >= 30)
                {
                    projectile.velocity.Y += height + 7;

                    Tile tileBelow = Main.tile[(int)projectile.Center.X / 16, (int)projectile.Center.Y / 16 + 1];
                    if (Main.tileSolid[tileBelow.type] && tileBelow.active()) // Checks if minion is on the ground
                    {
                        jumping = false;
                        AI_State = State_Waiting;
                    }
                }

                AI_Timer += 1;
            }
            else if (AI_State == State_Notice)
            {
                Vector2 directionToEnemy = projectile.DirectionTo(enemy.Center);

                if (dist > 1200) // If too far away from the player
                {
                    AI_State = State_Far;
                }
                else
                {
                    if (Vector2.Distance(enemy.Center, projectile.Center) < 500) // If the enemy is still in range
                    {
                        projectile.direction = directionToEnemy.X > 0 ? -1 : 1;
                        projectile.velocity = directionToEnemy * 5;
                    }
                    else // If the enemy has gone out of range
                    {
                        enemy = null;
                        AI_State = State_Waiting;
                    }
                }

                if (!enemy.active) // If the enemy has died
                {
                    enemy = null;
                    AI_State = State_Waiting;
                }

                BlockJump();
            }
            else if (AI_State == State_Flying)
            {
                if (projectile.velocity.X > 0)
                {
                    projectile.direction = 1; // Used for switching the sprite direction (in SelectFrame)
                }
                else if (projectile.velocity.X < 0)
                {
                    projectile.direction = 1;
                }

                int multi = 5;

                if (dist <= 20)
                {
                    multi = 1;
                }
                else if (dist <= 40)
                {
                    multi = 2;
                }
                else if (dist <= 60)
                {
                    multi = 3;
                }
                else if (dist <= 80)
                {
                    multi = 4;
                }

                projectile.velocity = directionToPlayer * multi;

                Tile tileBelow = Main.tile[(int)player.Bottom.X / 16, (int)player.Bottom.Y / 16 + 1];
                if (Main.tileSolid[tileBelow.type] && tileBelow.active())
                {
                    jumping = false;
                    AI_State = State_Waiting;
                }

                if (dist > 700)
                {
                    AI_State = State_Far;
                }
            }

            if (!jumping)
            {
                projectile.velocity.Y += 6f; // Gravity! (It just forces the minion to stay on the ground unless it's jumping or flying)
            }

            //Main.NewText("State: " + AI_State);

            // So the minions don't clump together in the same spot
            var minionList = Main.projectile.Where(x => x.active && x.type == mod.ProjectileType("Bunny"));
            foreach (Projectile proj in minionList)
            {
                if (proj != projectile)
                {
                    Vector2 distance = projectile.position - proj.position;
                    if (distance.Length() < 30)
                    {
                        Main.NewText(Vector2.Normalize(distance) * 4);
                        projectile.velocity += Vector2.Normalize(distance) * 4;
                    }
                }
            }

            SelectFrame(); // So it is animated
        }
        

        private void BlockJump() // Checks if there is a block to the left or right of the minion and if there is then switch state to jump over the block
        {
            if (projectile.velocity.X > 0)
            {
                for (int i = 1; i < 4; i++) // Using a for loop so it can see blocks more than just 1 block ahead of it
                {
                    // Checks if there is a block to the right of the minion
                    Tile right = Main.tile[(int)projectile.Center.X / 16 + i, (int)projectile.Center.Y / 16];
                    if (Main.tileSolid[right.type] && right.active())
                    {
                        AI_State = State_BlockRight;
                        AI_Timer = 0;
                        blockLocationX = (int)projectile.Center.X / 16 + i;
                        blockLocationY = (int)projectile.Center.Y / 16;
                        break;
                    }
                }
            }

            if (projectile.velocity.X < 0)
            {
                for (int i = 1; i < 4; i++) // Using a for loop so it can see blocks more than just 1 block ahead of it
                {
                    // Checks if there is a block to the left of the minion
                    Tile left = Main.tile[(int)projectile.Center.X / 16 - i, (int)projectile.Center.Y / 16];
                    if (Main.tileSolid[left.type] && left.active())
                    {
                        AI_State = State_BlockLeft;
                        AI_Timer = 0;
                        blockLocationX = (int)projectile.Center.X / 16 - i;
                        blockLocationY = (int)projectile.Center.Y / 16;
                        break;
                    }
                }
            }
        }

        /*public override void Behavior()
        {
            Player player = Main.player[projectile.owner];
            targetPos = player.Center;

            aboveGround = !hitTile; // If hitTile is true then aboveGround is false and vice versa

            float dist = Vector2.Distance(projectile.Center, targetPos);
            float verticalDist = targetPos.Y - projectile.Center.Y;

            if (dist > 700)
            {
                // Teleport if the player is minion is far away enough
                projectile.position = targetPos;
            }

            // Checks if there is a block to the right of the minion
            noBlockRight = Collision.CanHitLine(projectile.position, 5, 5, projectile.position + new Vector2(20, 0), 5, 5);
            // Checks if there is a block to the left of the minion
            noBlockLeft = Collision.CanHitLine(projectile.position, 5, 5, projectile.position - new Vector2(20, 0), 5, 5);
            

            tVel = dist / 20; // Changes based on how far away the minion is from the player

            if (vMag < vMax && vMag < tVel) // Whether to accelerate or to decelerate
            {
                vMag += vAccel; // Speed up
            }
            if (vMag > tVel)
            {
                vMag -= vAccel; // Slow down
            }
            
            // Changes velocity based on the direction to the player
            projectile.velocity = projectile.DirectionTo(targetPos) * vMag;

            if (verticalDist < 100 && noBlockLeft && noBlockRight && jumpTimer <= 0) // So it stays on the ground unless the player is flying
            {
                projectile.velocity.Y += 8; // It's like gravity
            }

            //jumpDelayTimer -= 1;
            //Main.NewText(jumpDelayTimer);
            jumpTimer -= 1;
            if ((!noBlockLeft || !noBlockRight) && hitTile && jumpTimer <= 0)
            {
                // Jump
                //jumpDelayTimer = 200;
                jumpTimer = 200;
                Main.NewText("Jump!");
                projectile.velocity.Y -= 50;
            }

            // Reverses sprite based on if it is moving right or left
            if (projectile.velocity.X > 0.03) // Decimal so if it is moving very slowly it won't change the direction
            {
                projectile.spriteDirection = -1;
            }
            else if (projectile.velocity.X < -0.03)
            {
                projectile.spriteDirection = 1;
            }

            SelectFrame(projectile.velocity); // Walking animation
        }*/

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
                    if (npc.CanBeChasedBy(projectile, false))
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