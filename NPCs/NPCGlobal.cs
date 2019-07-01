using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs
{
    public class NPCGlobal : GlobalNPC
    {
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
                if (Main.rand.Next(6) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameSkullStaff"));
                }
            }
        }
    }
}
