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
            npc.defense = 6;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = 0.5f;
            //npc.aiStyle = NPCID.DemonEye;
            animationType = NPCID.DemonEye;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.5f * NPC.downedBoss1.ToInt();
        }

        private const int AI_State_Slot = 0;
        private const int AI_Timer_Slot = 1;

        private const int State_Search = 0;
        private const int State_Found = 1;
        private const int State_Lock = 2;
        private const int State_Dash = 3;

        public float AI_State
        {
            get => npc.ai[AI_State_Slot];
            set => npc.ai[AI_State_Slot] = value;
        }

        public float AI_Timer
        {
            get => npc.ai[AI_Timer_Slot];
            set => npc.ai[AI_Timer_Slot] = value;
        }

        public override void AI()
        {
            if (AI_State == State_Search)
            {
            }
            else if (AI_State == State_Found)
            {
            }
            else if (AI_State == State_Lock)
            {
            }
            else if (AI_State == State_Dash)
            {
            }
        }
    }
}