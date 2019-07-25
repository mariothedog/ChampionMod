using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs
{
    public class NPCGlobal : GlobalNPC
    {
        readonly static List<int> bloodMoonEnemies = new List<int>() // Enemies that spawn during a blood moon
        { NPCID.TheGroom, NPCID.TheBride, NPCID.BloodZombie, NPCID.Drippler, // Common
        NPCID.CorruptBunny, NPCID.CorruptGoldfish, NPCID.CorruptPenguin, // Corruption
        NPCID.CrimsonBunny, NPCID.CrimsonGoldfish, NPCID.CrimsonPenguin, // Crimson
        NPCID.Clown}; // Hardmode

        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.KingSlime)
            {
                if (!Main.expertMode) // If it is expert it will drop from the bag anyway
                {
                    // Only if not expert (5-15 inclusive)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KingsGel"), Main.rand.Next(5, 16));
                }
            }

            if (npc.type == NPCID.IchorSticker)
            {
                if (Main.rand.Next(50) == 0) // 2% item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorBlaster"));
                }
            }

            if (npc.type == NPCID.GoblinSummoner)
            {
                if (Main.expertMode)
                {
                    if (Main.rand.Next(3) == 0) // 33.3% drop chance
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameSkullStaff"));
                    }
                }
                else
                {
                    if (Main.rand.Next(6) == 0) // 16.7% drop chance
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameSkullStaff"));
                    }
                }
            }

            if (bloodMoonEnemies.Contains(npc.type))
            {
                if (Main.expertMode)
                {
                    if (Main.rand.Next(200) == 0) // 0.5% drop chance
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AgonyBearer"));
                    }
                }
                else
                {
                    if (Main.rand.Next(400) == 0) // 0.25% drop chance
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AgonyBearer"));
                    }
                }
            }
        }
    }
}