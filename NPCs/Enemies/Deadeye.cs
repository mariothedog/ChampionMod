using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs.Enemies
{
    class Deadeye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.width = 36;
            npc.height = 22;
            npc.damage = 14;
            npc.defense = 2;
            npc.lifeMax = 80;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            //npc.aiStyle = NPCID.DemonEye;
            animationType = NPCID.DemonEye;
        }

        /*public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.5f * NPC.downedBoss1.ToInt();
        }*/

        private const int AI_State_Slot = 0;
        private const int AI_Lock_Timer_Slot = 1;
        private const int AI_Dash_Timer_Slot = 2;
        //private const int AI_Dash_End_Timer_Slot = 3;

        private const int State_Search = 0;
        private const int State_Found = 1;
        private const int State_Lock = 2;
        private const int State_Dash = 3;
        private const int State_Run = 4;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }

        public float AI_Lock_Timer
        {
            get => npc.ai[AI_Lock_Timer_Slot];
            set => npc.ai[AI_Lock_Timer_Slot] = value;
        }

        public float AI_Dash_Timer
        {
            get => npc.ai[AI_Dash_Timer_Slot];
            set => npc.ai[AI_Dash_Timer_Slot] = value;
        }

        /*public float AI_Dash_End_Timer
        {
            get => npc.ai[AI_Dash_End_Timer_Slot];
            set => npc.ai[AI_Dash_End_Timer_Slot] = value;
        }*/

        readonly int maxSpeed = 4;
        readonly float accel = 0.1f;
        const int lockDelay = 100;
        const int dashDelay = 100;
        //const int dashEndDelay = 100;
        //float targetVel = 0;
        float speed = 0;
        const float dashSpeed = 8;
        const float runSpeed = 5;

        readonly Vector2 offset = new Vector2(0, -120);

        Vector2 targetPos;
        Vector2 runDir;
        //Vector2 directionTo;
        //Vector2 oldDirectionTo;

        float dirX = 0;

        public override void AI()
        {
            npc.noGravity = true;

            Player player = Main.player[npc.target];

            targetPos = player.Center + offset;

            float dist = Vector2.Distance(npc.Center, targetPos);

            if (AI_State != State_Run)
            {
                if ((dist > 400 && (AI_State != State_Lock || AI_State != State_Dash)) || Main.dayTime)
                {
                    runDir = npc.DirectionTo(targetPos);
                    runDir.X *= -1;
                    AI_State = State_Run;
                }
                else
                {
                    if (AI_State == State_Search)
                    {
                        AI_State = State_Found;
                    }
                }

                if (dirX == 0)
                {
                    dirX = Math.Sign(npc.DirectionTo(targetPos).X);
                }
            }

            if (AI_State == State_Found)
            {
                if (speed < maxSpeed)
                {
                    speed += accel;
                }

                if (dist != 0)
                {
                    if (dist > 200 && Math.Round(npc.DirectionTo(targetPos).X) != 0)
                    {
                        dirX = Math.Sign(npc.DirectionTo(targetPos).X);
                        npc.rotation = npc.velocity.ToRotation();
                    }

                    //directionTo = npc.DirectionTo(targetPos);

                    npc.velocity = new Vector2(dirX, npc.DirectionTo(targetPos).Y) * speed;

                    //oldDirectionTo = directionTo;
                }

                AI_Lock_Timer += 1;
                if (AI_Lock_Timer == lockDelay)
                {
                    AI_Lock_Timer = 0;
                    AI_State = State_Lock;
                }
            }
            else if (AI_State == State_Lock)
            {
                //npc.rotation = 0;//npc.DirectionTo(targetPos).ToRotation();
                //npc.direction = 1;
                //npc.TargetClosest(true);
                //npc.FaceTarget();
                //npc.rotation = npc.DirectionTo(player.Center).ToRotation();
                npc.rotation = RotationToPos(player.Center);

                AI_Dash_Timer += 1;
                if (AI_Dash_Timer == dashDelay)
                {
                    AI_Dash_Timer = 0;
                    AI_State = State_Dash;
                }
            }
            else if (AI_State == State_Dash)
            {
                npc.velocity = npc.DirectionTo(player.Center) * dashSpeed;

                for (int i = 0; i < 2; i++)
                {
                    Dust dust = Main.dust[Dust.NewDust(npc.position, 30, 30, 5, 0f, 0f, 0, new Color(255, 255, 255), 1.2f)];
                    dust.noGravity = true;
                }


                // Can't use dist because dist is the distance between the NPC and the targetPos (which includes the offset)
                if (Vector2.Distance(npc.Center, player.Center) <= 10) // Once the NPC has hit the player
                {
                    AI_State = State_Found;
                }
            }
            else if (AI_State == State_Run)
            {
                npc.velocity = runDir * runSpeed;
            }

            //Main.NewText(AI_Lock_Timer);
            //Main.NewText(string.Format("State: {0}, Distance: {1}, Thing: {2}, Velocity: {3}", AI_State, dist, npc.DirectionTo(targetPos).X, npc.velocity));
            //Main.NewText(string.Format("State: {0}, Rotation: {1}, Direction: {2}", AI_State, npc.rotation, npc.direction));

            //Main.NewText(string.Format("State: {0}, Dist: {1}, Velocity: {2}", AI_State, dist, npc.velocity));
        }

        float RotationToPos(Vector2 pos)
        {
            float rot = npc.DirectionTo(pos).ToRotation();
            if (npc.direction == -1)
            {
                rot -= (float)Math.PI;
            }
            return rot;
        }
    }
}