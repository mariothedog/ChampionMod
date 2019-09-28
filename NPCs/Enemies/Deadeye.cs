using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs.Enemies
{
    class Deadeye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            //Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
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
            npc.aiStyle = NPCID.DemonEye;
            animationType = NPCID.DemonEye;
        }

        public override void AI()
        {
        }
    }
}
