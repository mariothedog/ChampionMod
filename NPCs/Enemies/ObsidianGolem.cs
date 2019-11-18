/*using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChampionMod.NPCs.Enemies
{
    public class ObsidianGolem : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Golem");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GraniteGolem];
        }

        public override void SetDefaults()
        {
            npc.width = 28;
            npc.height = 48;
            npc.aiStyle = -1;
            npc.damage = 45;
            npc.defense = 20;
            npc.lifeMax = 240;
            npc.HitSound = SoundID.NPCHit41;
            npc.DeathSound = SoundID.NPCDeath44;
            npc.knockBackResist = 0.70f;
            npc.value = 750f;
            npc.buffImmune[20] = true;
            npc.buffImmune[24] = true;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            // we would like this npc to spawn in the overworld.
            return SpawnCondition.Underworld.Chance * 0.1f;
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Obsidian, Main.rand.Next(10, 31));
            if (Main.expertMode)
            {
                if (Main.rand.Next(1000) <= 25)
                    Item.NewItem(npc.getRect(), ItemID.LavaCharm);
            }
            else
            {
                if (Main.rand.Next(1000) <= 13)
                    Item.NewItem(npc.getRect(), ItemID.LavaCharm);
            }
        }
        public override void AI()
        {
            int num8 = 300;
            int num9 = 120;
            npc.dontTakeDamage = false;

            if (npc.ai[2] < 0f)
            {
                npc.dontTakeDamage = true;
                npc.ai[2] += 1f;
                npc.velocity.X *= 0.9f;

                if ((double)Math.Abs(npc.velocity.X) < 0.001)
                {
                    Main.NewText("first");
                    npc.velocity.X = 0.001f * (float)npc.direction;
                }

                if (Math.Abs(npc.velocity.Y) > 1f)
                {
                    Main.NewText("second");
                    npc.ai[2] += 10f;
                }

                if (npc.ai[2] >= 0f)
                {
                    Main.NewText("third");
                    npc.netUpdate = true;
                    npc.velocity.X += (float)npc.direction * 0.3f;
                }

                return;
            }

            if (npc.ai[2] < (float)num8)
            {
                if (npc.justHit)
                {
                    npc.ai[2] += 15f;
                }
                npc.ai[2] += 1f;
            }
            else if (npc.velocity.Y == 0f)
            {
                npc.ai[2] = -num9;
                npc.netUpdate = true;
            }
        }
    }
}*/